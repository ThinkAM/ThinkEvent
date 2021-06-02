import { ThinkEventTemplatePage } from './app.po';

describe('ThinkEvent App', function() {
  let page: ThinkEventTemplatePage;

  beforeEach(() => {
    page = new ThinkEventTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
