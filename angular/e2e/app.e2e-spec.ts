import { ABPCommerceTemplatePage } from './app.po';

describe('ABPCommerce App', function() {
  let page: ABPCommerceTemplatePage;

  beforeEach(() => {
    page = new ABPCommerceTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
