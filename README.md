1. driver.FindElement(By.CssSelector("локатор")).Click();                        //Нажатие по элементу
2. driver.FindElement(By.CssSelector("локатор")).SendKeys(“Текст ввода”);        //Ввод текста
3. driver.FindElement(By.CssSelector("локатор")).Clear();                        //Очистка поля от текста
4. new Actions(driver).moveToElement(drag).keyDown(Keys.CONTROL).clickAndHold()
.moveToElement(drop).release().keyUp(Keys.CONTROL).perform();                    //Сложные действия
5. driver.FindElement(By.Xpath("//*[contains(@class, 'Текст')]"))                //Локатор построенный на поиске определенного текста, можно использовать ка кпроверки
6. Assert //проверка соответствия**
