import { UsersListDef } from '../../components/users-list/users-list.js';

const _UsersListView = async (res, rej) => {
  const tpl = await RawCMS.loadComponentTpl(
    '/modules/core/views/users-list-view/users-list-view.tpl.html'
  );
  const list = await UsersListDef();

  res({
    components: {
      UsersList: list,
    },
    data: function() {
      return {};
    },
    methods: {
      goToCreateView: function() {
        this.$router.push({ name: 'user-details', params: { id: 'new' } });
      },
    },
    template: tpl,
  });
};

export const UsersListView = _UsersListView;
export default _UsersListView;
