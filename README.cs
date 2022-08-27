//Необходимые NuGet пакеты:
//1. DotNetSeleniumExtras.WaitHelpers 3.11.0
//2. NSelene 1.0.0-alpha10
//3. NUnit 3.12.0
//4. NUnit3TestAdapter 3.16.1
//5. Selenium.Support 4.4.0
//6. Selenium.WebDriver 4.4.0
//7. Selenium.WebDriver.ChromeDriver ВЕРСИЯ ДРАЙВЕРА ЗАВИСИТ ОТ БРАУЗЕРА

//Инициализация браузера
private IWebDriver driver = new ChromeDriver();

//Инициализация wait
private WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

//Закрыть браузер
driver.Quit();

1. driver.FindElement(By.CssSelector("локатор")).Click();                        //Нажатие по элементу
2. driver.FindElement(By.CssSelector("локатор")).SendKeys(“Текст ввода”);        //Ввод текста
3. driver.FindElement(By.CssSelector("локатор")).Clear();                        //Очистка поля от текста
4. new Actions(driver).moveToElement(drag).keyDown(Keys.CONTROL).clickAndHold()
.moveToElement(drop).release().keyUp(Keys.CONTROL).perform();                    //Сложные действия
5. driver.FindElement(By.Xpath("//*[contains(@class, 'Текст')]"));               //Локатор построенный на поиске определенного текста, можно использовать ка кпроверки
6. Assert //проверка соответствия
7. Alert alert = driver.switchTo().alert();
8. Alert alert = wait.until(alertIsPresent());
9. alert.getText();
10. alert.sendKeys();
11. alert.accept();
12. alert.dismiss();
13. caps.setCapability("unexpectedAlertBehaviour", "dismiss");
14. driver.switchTo().frame(element)                                             //Переход во фрейм
15. driver.switchTo().defaultContent()                                           //Переход на дефолтную страницу
16. driver.switchTo().parentFrame()
17. wait.until(visibilityOf(element))
18. wait.until(visibilityOfAllElements(elementList))
19. wait.until(not(visibilityOf(element)))
20. wait.until(invisibilityOfAllElements(elementList))
21. wait.until(visibilityOfElementLocated(locator))
