import { RawCMS } from '../../../../config/raw-cms.js';
import { evtToggleDrawer } from '../../events.js';

const _TopBar = async (resolve, reject) => {
  const tpl = await RawCMS.loadComponentTpl('/modules/core/components/top-bar/top-bar.tpl.html');

  resolve({
    methods: {
      toggleDrawer: function() {
        RawCMS.eventBus.$emit(evtToggleDrawer);
      },
    },
    template: tpl,
  });
};

export const TopBar = _TopBar;
export default _TopBar;
