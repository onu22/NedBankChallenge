import { NedbankTestTemplatePage } from './app.po';

describe('NedbankTest App', function() {
  let page: NedbankTestTemplatePage;

  beforeEach(() => {
    page = new NedbankTestTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
