import {FrameworkConfiguration, PLATFORM} from 'aurelia-framework';

export function configure(config: FrameworkConfiguration) {
  config.globalResources(
    [
      PLATFORM.moduleName('./custom-elements/tag-editor/tag-editor'),
      PLATFORM.moduleName('./custom-elements/result-list/result-list')
    ]);
}
