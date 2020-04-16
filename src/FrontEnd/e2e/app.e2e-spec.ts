import { BusyPage } from './app.po';

describe('busy App', () => {
  let page: BusyPage;

  beforeEach(() => {
    page = new BusyPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
