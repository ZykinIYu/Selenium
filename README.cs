//Необходимые NuGet пакеты:
//1. DotNetSeleniumExtras.WaitHelpers 3.11.0
//2. NSelene 1.0.0-alpha10
//3. NUnit 3.12.0
//4. NUnit3TestAdapter 3.16.1
//5. Selenium.Support 4.4.0
//6. Selenium.WebDriver 4.4.0
//7. Selenium.WebDriver.ChromeDriver ВЕРСИЯ ДРАЙВЕРА ЗАВИСИТ ОТ БРАУЗЕРА

//Необходимые расширения
NUnit 3 Test Adapter

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

//Сложные действия над элементами
            new Actions(driver)
                .MoveToElement(driver.FindElement(By.XPath("//span[2]/button"))) //Перевести курсор на элемент
                .KeyDown(Keys.Control)                                           //Зажать кнопку Control
                .ClickAndHold()                                                  //Нажать и удерживать кнопку мыши
                .MoveToElement(driver.FindElement(By.XPath("//span[3]/button"))) //Перевести курсор на элемент
                .Release()                                                       //Отпустить кнопку мыши
                .KeyUp(Keys.Control)                                             //Отпустить кнопку Control
                .DoubleClick()                                                   //Двойной клик кнопкой мыши
                .Perform();                                                      //Закончить сложную операцию

//Работа с Alert
driver.SwitchTo().Alert().SendKeys("Текст"); //Ввод текста в Alert
driver.SwitchTo().Alert().Accept();          //Имитация нажатия "Ok"
driver.SwitchTo().Alert().Dismiss();         //Имитация нажатия "Отмена"

//Работа с окнами
var c = driver.WindowHandles;       //Запоминаем идентификатор текущего окна
var d = driver.CurrentWindowHandle; //Запоминаем идентификаторы всех открытых окон
driver.SwitchTo().Window(c);        //Переключение на другое окно
driver.SwitchTo().NewWindow();      //
driver.Close();                     //Закрыть текущее окно
driver.Quit();                      //Закрыть все открытые окна

//Операции с фреймами
driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("#frame"))); //Переключение во фрейм
driver.SwitchTo().DefaultContent();                                    //Выход из фрейма на главную страницу
driver.SwitchTo().ParentFrame();                                       //Выход из фрейма на уровень выше

//Размер и положение окон
var f = driver.Manage().Window.Position; //Запись положения окна
driver.Manage().Window.Minimize();       //Задать минимальный размер окна
driver.Manage().Window.Maximize();       //Задать максимальный размер окна
driver.Manage().Window.FullScreen();     //Перевести окно в полноэкранный режим
var g = driver.Manage().Window.Size;     //Запись размера окна

//Работа с неявными ожиданиями
driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30); //Ожидание  прогрузки сраницы не более 30 секунд

//Работа с явными ожиданиями
wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("[name = 'q']"))); //Ожидание кликабельности элемента
wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("[name = 'q']"))); //Ожидание видимости элемента

//Фреймворк NSelen, проверки с локатором
S("[name = 'q']", driver).Should(Be.Blank); //Поиск элемента по локатору и проверка что он пустой
S("[name = 'q']", driver).Should(Be.Enabled); //Поиск элемента по локатору и проверка что он есть на странице
S("[name = 'q']", driver).Should(Be.InDom); //Поиск элемента по локатору и проверка что он существует в DOM дереве
S("[name = 'q']", driver).Should(Be.Selected); //Поиск элемента по локатору и проверка что он выбран
S("[name = 'q']", driver).Should(Be.Visible); //Поиск элемента по локатору и проверка что он видимый
S("[name = 'q']", driver).Should(Be.Not.Blank); //Поиск элемента по локатору и проверка что он не пустой
S("[name = 'q']", driver).Should(Be.Not.Enabled); //Поиск элемента по локатору и проверка что он отсутствует на странице
S("[name = 'q']", driver).Should(Be.Not.InDom); //Поиск элемента по локатору и проверка что он не существует в DOM дереве
S("[name = 'q']", driver).Should(Be.Not.Selected); //Поиск элемента по локатору и проверка что он не выбран
S("[name = 'q']", driver).Should(Be.Not.Visible);              //Поиск элемента по локатору и проверка что он не видимый
S("[name = 'q']", driver).Should(Have.Text("Какой то текст")); //Поиск элемента по локатору и проверка что в элементе есть указанный текст
S("[name = 'q']", driver).Should(Have.No.Text("Какой то текст")); //Поиск элемента по локатору и проверка что в элементе нет указанного текста

//Фреймворк NSelen, действия
S("[name = 'q']", driver).Should(Be.Visible).Clear(); //Стереть значение в поле
S("[name = 'q']", driver).Should(Be.Visible).Click(); //Клик
S("[name = 'q']", driver).Should(Be.Visible).DoubleClick(); //Двойной клик
S("[name = 'q']", driver).Should(Be.Visible).Hover(); //Навести курсор
S("[name = 'q']", driver).Should(Be.Visible).PressEnter(); //Нажать Enter
S("[name = 'q']", driver).Should(Be.Visible).PressEscape(); //Нажать Esc
S("[name = 'q']", driver).Should(Be.Visible).PressTab(); //Нажать Tab
S("[name = 'q']", driver).Should(Be.Visible).SendKeys("Текст"); //Ввод текста
S("[name = 'q']", driver).Should(Be.Visible).SetValue("Текст"); //Стереть текст в поле и ввести заного

//NUnit
NUnit.Framework.Assert.IsFalse(driver.PageSource.Contains("Текст"));

