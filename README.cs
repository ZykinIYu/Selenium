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

//Команды поиска
IWebElement element = driver.FindElement(<локатор>);                      //Поиск и запись первого найденного элемента
ReadOnlyCollection<IWebElement> elements = driver.findElements(<локатор>) //Поиск и запись всех найденных элементов в массив

//Стратегии поиска
driver.FindElement(By.Id("Локатор"));              //Поиск по ID
driver.FindElement(By.TagName("Локатор"));         //Поиск по тегу
driver.FindElement(By.ClassName("Локатор"));       //Поиск по классу
driver.FindElement(By.CssSelector("Локатор"));     //Поиск с помощью CssSelector запросов
driver.FindElement(By.Name("Локатор"));            //Поиск по Имени
driver.FindElement(By.LinkText("Локатор"));        //Поиск по тексту ссылки
driver.FindElement(By.PartialLinkText("Локатор")); //Поиск по частичному тексту ссылки
driver.FindElement(By.XPath("Локатор"));           //Поиск с помощью XPath запросов

//Проверка значения атрибута CssSelector
driver.FindElement(By.CssSelector("[checked]"));       //Наличие атрибута
driver.FindElement(By.CssSelector("[name = email]"));  //Совпадение значения
driver.FindElement(By.CssSelector("[title *= Name]")); //Содержится текст
driver.FindElement(By.CssSelector("[src ^= http]"));   //Начинается с текста
driver.FindElement(By.CssSelector("[src $= .pdf]"));   //Заканчивается текстом

//Проверка значения атрибута XPath
driver.FindElement(By.XPath("//*[@checked]"));                  //Наличие атрибута
driver.FindElement(By.XPath("//*[@name='email']"));             //Совпадение значения
driver.FindElement(By.XPath("//*[contains(@title, 'Name')]"));  //Содержится текст
driver.FindElement(By.XPath("//*[starts-with(@src, 'http')]")); //Начинается с текста

//Комбинация условий CssSelector
driver.FindElement(By.CssSelector("label"));                    //По тегу
driver.FindElement(By.CssSelector(".error"));                   //По классу
driver.FindElement(By.CssSelector("label.error"));              //По тегу и классу
driver.FindElement(By.CssSelector("label.error.fatal"));        //По тегу и двум классам
driver.FindElement(By.CssSelector("label.error[for = email]")); //По тегу, классу и атрибуту

//Комбинация условий XPath
driver.FindElement(By.XPath("//label"));                                                                           //По тегу 
driver.FindElement(By.XPath("//*[contains(@class, 'error')]"));                                                    //По классу
driver.FindElement(By.XPath("//label[contains(@class, 'error')]"));                                                //По тегу и классу
driver.FindElement(By.XPath("//label[contains(@class, 'error') and contains(@class, 'fatal')]"));                  //По тегу и двум классам
driver.FindElement(By.XPath("//label[contains(@class, 'error') and contains(@class, 'fatal') and @for='email']")); //По тегу, классу и атрибуту

//Отрицание условий
driver.FindElement(By.CssSelector("label:not(.error)"));        //Сообщения не об ошибках
driver.FindElement(By.CssSelector("input:not([type = text])")); //Нетекстовые поля ввода
driver.FindElement(By.CssSelector("a:not([href ^= http])"));    //Локальные ссылки

//Движение по дереву CssSelector
driver.FindElement(By.CssSelector("div#main p"));                      //p где-то внутри блока div#main
driver.FindElement(By.CssSelector("div#main > p"));                    //p непосредственно внутри div#main
driver.FindElement(By.CssSelector("div#main li:first-child"));         //Первый элемент списка
driver.FindElement(By.CssSelector("div#main li:last-child"));          //Последний элемент списка
driver.FindElement(By.CssSelector("div#main li:nth-child(1)"));        //Элемент списка по номеру
driver.FindElement(By.CssSelector("div#header > div:nth-of-type(1)")); //Из всех детей родителя берется только кто имеет нужный тип и по номеру

//Движение по дереву XPath
driver.FindElement(By.XPath("//div[@id='main']//p"));                           //p где-то внутри блока div#main
driver.FindElement(By.XPath("//div[@id='main']/p"));                            //p непосредственно внутри div#main
driver.FindElement(By.XPath("//div[@id='main']/div[1]"));                       //Из всех детей родителя берется только кто имеет нужный тип и по номеру
driver.FindElement(By.XPath("//input[@id='search']/../input[@type='button']")); //Движение по дереву снизу вверх

//Поиск по тексту с помощью XPath
driver.FindElement(By.XPath("//a[contains(., 'Edit')]"));

//Формирование подзапросов с помощью XPath
driver.FindElement(By.XPath("//form[.//input[@name='password']]"));

//Контекст поиска
input = driver.FindElement(By.Name("password"));
form = driver.FindElement(By.Id("login-modal"));
input = form.FindElement(By.Name("password")); 
/*Данная запись не равна, записи ниже*/
input = driver.FindElement(By.CssSelector("#login-modal [name=password]"));

//Относительные запросы XPath
form = driver.FindElement(By.Id("login-modal"));
input = form.FindElement(By.XPath(".//input[@name='password']"));

//Получение аттрибутов элементов
driver.FindElement(By.XPath("//label")).GetAttribute("value"); //Содержимое полей ввода
driver.FindElement(By.XPath("//label")).GetAttribute("href");  //Нормализация адресов
driver.FindElement(By.XPath("//label")).GetAttribute("src");   //Нормализация адресов
driver.FindElement(By.XPath("//label")).GetAttribute("true");  //Булевские атрибуты
driver.FindElement(By.XPath("//label")).GetAttribute("null");  //Булевские атрибуты

//Получение стиля элемента
driver.FindElement(By.XPath("//label")).GetCssValue("propertyName");

//Получение размера и положения
var a = driver.FindElement(By.XPath("//label")).Size;     //Размер элемента (в пикселях)
var b = driver.FindElement(By.XPath("//label")).Location; //Положение на странице

//Простые действия над элементами
driver.FindElement(By.XPath("//span[2]/button")).Click();                     //Нажатие на кликабельный элемент
driver.FindElement(By.XPath("//span[2]/button")).Submit();                    //Нажатие на любой элемент
driver.FindElement(By.XPath("//span[2]/button")).SendKeys("Текст для ввода"); //Печать текста
driver.FindElement(By.XPath("//span[2]/button")).SendKeys(Keys.Enter);        //Имитация нажатия кнопки на клавиатуре
driver.FindElement(By.XPath("//span[2]/button")).Clear();                     //Очистка поля для ввода


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
