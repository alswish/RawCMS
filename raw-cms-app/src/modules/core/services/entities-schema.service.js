import { apiClient } from '../api/api-client.js';

class EntitiesSchemaService {
  _apiClient;

  constructor() {
    this._apiClient = apiClient;
  }

  async getEntities(page = 0) {
    // FIXME: Handle pagination (maybe in api client?)
    const res = await this._apiClient.get('/system/admin/_schema');
    return res.data.data.items;
  }

  async getEntityDetails(entityId) {
    const res = await this._apiClient.get('/system/admin/_schema/' + entityId);
    return res.data.data.FieldSettings;
  }
}

export const entitiesSchemaService = new EntitiesSchemaService();
export default entitiesSchemaService;
