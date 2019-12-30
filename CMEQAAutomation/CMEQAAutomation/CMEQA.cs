using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

using System.Configuration;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CMEQAAutomation
{
    [TestClass]
    public class CMEQA
    {
        IWebDriver driver;
        Cmebase objbase = new Cmebase();
        string selectedserver = "";

        [TestMethod]
        public void ValidateCashManagementEngine()
        {
                try
                {
                    
                    driver = objbase.DriverInitialization();
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                    selectedserver = ConfigurationSettings.AppSettings["Server"];
                    if(selectedserver=="Production")
                    {
                                               
                        driver.Navigate().GoToUrl(ConfigurationSettings.AppSettings["productionURL"]);
                        driver.Manage().Window.Maximize();
                        objbase.waitforPageload();
                       

                        bool tblusersexists = objbase.validatelementexist(By.Id("ctl00_Main_UserlistTbl"));
                        if(tblusersexists)
                        {
                            IWebElement tbluserlist = driver.FindElement(By.Id("ctl00_Main_UserlistTbl"));
                            objbase.waitforPageload();
                            IWebElement eleuseracclnk = tbluserlist.FindElement(By.LinkText("My Account"));
                            executor.ExecuteScript("arguments[0].click();", eleuseracclnk);
                            objbase.waitforPageload();
                        }
                        else
                        { }
                        
 
                        IWebElement Cmeenginelnk = driver.FindElement(By.LinkText("Cash Management Engine"));
                        executor.ExecuteScript("arguments[0].click();", Cmeenginelnk);
                        objbase.waitforPageload();

                        var element = driver.FindElement(By.XPath("//*[@id='PEMenu_4689']"));
                        objbase.waitforPageload();
                       
                        executor.ExecuteScript("arguments[0].click();", element);
                        objbase.waitforPageload();

                        var eleSearch = driver.FindElement(By.XPath("//*[@id='PEMenu_4690']"));
                        objbase.waitforPageload();
                        executor.ExecuteScript("arguments[0].click();", eleSearch);
                        objbase.waitforPageload();

                        /* Calendar search */

                        IWebElement elebatchid = driver.FindElement(By.Id("contentBody_txtBatchID"));
                        elebatchid.SendKeys(ConfigurationSettings.AppSettings["Batchid"]);
                        objbase.waitforPageload();
                        var batchsearch = driver.FindElement(By.Id("contentBody_cmdOK"));
                        objbase.waitforPageload();
                        executor.ExecuteScript("arguments[0].click();", batchsearch);
                        objbase.waitforPageload();

                        /* Inbox Validation */

                        var elementInbx = driver.FindElement(By.XPath("//*[@id='PEMenu_4310']"));
                        objbase.waitforPageload();
                        executor.ExecuteScript("arguments[0].click();", elementInbx);
                        objbase.waitforPageload();

                        //contentBody_ddlWorklist

                        IWebElement eleorklist = driver.FindElement(By.Id("contentBody_ddlWorklist"));
                        SelectElement selworklist = new SelectElement(eleorklist);
                        selworklist.SelectByText(ConfigurationSettings.AppSettings["InboxWorkList"]);
                        objbase.waitforPageload();


                        bool batchesavbl = objbase.validatelementexist(By.Id("contentBody_tcInbox_tpToday_cmeToday_lvBatches_lnkUpdateBatch_0"));
                        if (batchesavbl)
                        {

                            IWebElement listbatchids = driver.FindElement(By.Id("contentBody_tcInbox_tpToday_cmeToday_lvBatches_lnkUpdateBatch_0"));
                            objbase.waitforPageload();
                            // IJavaScriptExecutor javascrexebatchid = (IJavaScriptExecutor)WebDriver;
                            executor.ExecuteScript("arguments[0].click();", listbatchids);

                        }
                        else
                        {
                            Console.WriteLine("FALSE RETURNED FROM DRIVER");
                        }


                        // Menu - Batch 

                        objbase.waitforPageload();
                        var elementbatch = driver.FindElement(By.XPath("//*[@id='PEMenu_4311']"));
                        objbase.waitforPageload();
                        executor.ExecuteScript("arguments[0].click();", elementbatch);
                        objbase.waitforPageload();

                        // Menu - Batch Search

                        objbase.waitforPageload();
                        var elementbatchsearch = driver.FindElement(By.XPath("//*[@id='PEMenu_4319']"));
                        objbase.waitforPageload();
                        executor.ExecuteScript("arguments[0].click();", elementbatchsearch);
                        objbase.waitforPageload();

                        IWebElement elebatchids = driver.FindElement(By.Id("txtCMEBatchRefNum"));
                        elebatchids.SendKeys(ConfigurationSettings.AppSettings["Batchid"]);
                        objbase.waitforPageload();

                        ////*[@id="btns"]
                        var batchid = driver.FindElement(By.Id("btns"));
                        executor.ExecuteScript("arguments[0].click();", batchid);
                        objbase.waitforPageload();

                        // Batch search from results 

                        IWebElement listofactivebatchids = driver.FindElement(By.LinkText(ConfigurationSettings.AppSettings["Batchid"]));
                        executor.ExecuteScript("arguments[0].click();", listofactivebatchids);
                        objbase.waitforBatchload();

                        // Approver Image validation

                        try
                        {

                            var apprimage = driver.FindElement(By.Id("divBatchDetailRowTop")).FindElement(By.Id("hlEscalation"));
                            objbase.waitforPageload();
                            executor.ExecuteScript("arguments[0].click();", apprimage);
                            objbase.waitforPageload();

                        }
                        catch (Exception exaprover)
                        { }

                        // Approver Refresh/Cancel Window

                        driver.SwitchTo().Window(driver.WindowHandles.Last());

                        try
                        {
                            IWebElement elementApprbtCancel = driver.FindElement(By.Id("btnCancel"));
                            executor.ExecuteScript("arguments[0].click();", elementApprbtCancel);
                            objbase.waitforPageload();
                        }
                        catch (Exception ex1)
                        { }

                        //  Validating Wires

                        Console.Write("welcome to wires ");
                        driver.SwitchTo().Window(driver.WindowHandles.Last());
                        objbase.waitforPageload();
                        var elementWiremenu = driver.FindElement(By.XPath("//*[@id='PEMenu_4312']"));
                        executor.ExecuteScript("arguments[0].click();", elementWiremenu);
                        objbase.waitforPageload();


                        var elementWiresearch = driver.FindElement(By.XPath("//*[@id='PEMenu_4320']"));
                        executor.ExecuteScript("arguments[0].click();", elementWiresearch);
                        objbase.waitforwire();

                        var wireid = driver.FindElement(By.Id("contentBody_txtWireID"));
                        wireid.SendKeys(ConfigurationSettings.AppSettings["WireId"]);
                        objbase.waitforwire();

                        var wiresearchbtn = driver.FindElement(By.Id("contentBody_btnSearch"));
                        objbase.waitforPageload();
                        executor.ExecuteScript("arguments[0].click();", wiresearchbtn);
                        objbase.waitforPageload();

                        // WIRE instruction search 

                        objbase.waitforPageload();
                        var elementWireInsSearch = driver.FindElement(By.XPath("//*[@id='PEMenu_4322']"));
                        executor.ExecuteScript("arguments[0].click();", elementWireInsSearch);
                        objbase.waitforPageload();

                        IWebElement eleddltype = driver.FindElement(By.Id("ddlType"));
                        SelectElement selddltype = new SelectElement(eleddltype);
                        selddltype.SelectByText(ConfigurationSettings.AppSettings["ddltype"]);
                        objbase.waitforwire();


                        IWebElement eleinvestorname = driver.FindElement(By.Id("EntityPickerControl_txtInvestorName"));
                        eleinvestorname.SendKeys(ConfigurationSettings.AppSettings["WireInvestorName"]);
                        objbase.waitforwire();

                        IWebElement eleretrive = driver.FindElement(By.Id("EntityPickerControl_btnInvestorName"));
                        executor.ExecuteScript("arguments[0].click();", eleretrive);
                        objbase.waitforwire();

                        driver.SwitchTo().Window(driver.WindowHandles.Last());
                        IWebElement eleinvestorfullname = driver.FindElement(By.LinkText("Texas Emerging Managers Private Markets Program, L.P."));
                        executor.ExecuteScript("arguments[0].click();", eleinvestorfullname);
                        objbase.waitforPageload();


                        IWebElement btnwireinssearch = driver.FindElement(By.Id("btnSearch"));
                        executor.ExecuteScript("arguments[0].click();", btnwireinssearch);
                        objbase.waitforPageload();

                        //Validating Active status from Wire Instructions search


                        bool activelinksfound = objbase.validatelementexist(By.LinkText("Active"));
                        if (activelinksfound)
                        {

                            IWebElement listofactivelinks = driver.FindElement(By.LinkText("Active"));
                            executor.ExecuteScript("arguments[0].click();", listofactivelinks);
                            objbase.waitforPageload();
                        }
                        else
                        { }
                        // Wire Instructions NEW

                        if (selectedserver == "UAT")
                        {
                            objbase.waitforPageload();
                            var elementWireInsnew = driver.FindElement(By.XPath("//*[@id='PEMenu_4321']"));
                            executor.ExecuteScript("arguments[0].click();", elementWireInsnew);
                            objbase.waitforPageload();
                        }
                        else
                        { }

                        // Report - Active Wire Instructions

                        var elementReportMenu = driver.FindElement(By.XPath("//*[@id='PEMenu_4314']"));
                        executor.ExecuteScript("arguments[0].click();", elementReportMenu);
                        objbase.waitforPageload();

                        objbase.waitforwire();
                        var elementReportInsSubmenu = driver.FindElement(By.XPath("//*[@id='PEMenu_5162']"));
                        executor.ExecuteScript("arguments[0].click();", elementReportInsSubmenu);
                        objbase.waitforPageload();

                        var elementlegalActivewirereports = driver.FindElement(By.Id("contentBody_dgReports_Hyperlink1_3"));
                        objbase.waitforwire();
                        executor.ExecuteScript("arguments[0].click();", elementlegalActivewirereports);
                        objbase.waitforPageload();

                        IWebElement elementtxtfund = driver.FindElement(By.Id("ctl00_contentBody_ReportViewer1_ctl04_ctl03_ddValue"));
                        SelectElement selectfundtype = new SelectElement(elementtxtfund);
                        selectfundtype.SelectByText(ConfigurationSettings.AppSettings["FundType"]);
                        objbase.waitforPageload();

                        IWebElement elementviewreport = driver.FindElement(By.Id("ctl00_contentBody_ReportViewer1_ctl04_ctl00"));
                        executor.ExecuteScript("arguments[0].scrollIntoView()", elementviewreport);
                        objbase.waitforPageload();
                        executor.ExecuteScript("arguments[0].click();", elementviewreport);
                        objbase.waitforPageload();

                        //Admin - User Maintanence - Leona Leung.

                        if(selectedserver=="Production")
                        { }
                        else
                        {
                            var elementpemenu = driver.FindElement(By.XPath("//*[@id='PEMenu_4308']"));
                            objbase.waitforPageload();
                            executor.ExecuteScript("arguments[0].click();", elementpemenu);
                            objbase.waitforPageload();

                            var elementWiAdminuser = driver.FindElement(By.LinkText(ConfigurationSettings.AppSettings["AdminUser"]));
                            objbase.waitforwire();
                            executor.ExecuteScript("arguments[0].click();", elementWiAdminuser);
                            objbase.waitforPageload();

                            var elementCashmgmtenginelink = driver.FindElement(By.LinkText("Cash Management Engine"));
                            executor.ExecuteScript("arguments[0].click();", elementCashmgmtenginelink);
                            objbase.waitforPageload();

                            var elementAdminmenuforusermaint = driver.FindElement(By.XPath("//*[@id='PEMenu_4779']"));
                            objbase.waitforPageload();
                            executor.ExecuteScript("arguments[0].click();", elementAdminmenuforusermaint);
                            objbase.waitforPageload();

                            //  User Maintanance and Entitlements
                            
                            var elementuserMaintmenu = driver.FindElement(By.XPath("//*[@id='PEMenu_4984']"));
                            objbase.waitforPageload();
                            executor.ExecuteScript("arguments[0].click();", elementuserMaintmenu);
                            objbase.waitforPageload();

                            IWebElement elementadduser = driver.FindElement(By.Id("contentBody_btnAddUser"));
                            executor.ExecuteScript("arguments[0].click();", elementadduser);
                            objbase.waitforPageload();

                            IWebElement elementuserid = driver.FindElement(By.Id("contentBody_gvUserList_txtDomainUserID"));
                            elementuserid.SendKeys(ConfigurationSettings.AppSettings["UserMaintananceAndEntitlements"]);
                            objbase.waitforwire();

                            IWebElement elementlastname = driver.FindElement(By.Id("contentBody_gvUserList_txtLastName"));
                            elementlastname.SendKeys(ConfigurationSettings.AppSettings["UserLastName"]);
                            objbase.waitforwire();

                            IWebElement elementfirstname = driver.FindElement(By.Id("contentBody_gvUserList_txtFirstName"));
                            elementfirstname.SendKeys(ConfigurationSettings.AppSettings["UserFirstName"]);
                            objbase.waitforwire();

                            IWebElement elementemail = driver.FindElement(By.Id("contentBody_gvUserList_txtEmail"));
                            elementemail.SendKeys(ConfigurationSettings.AppSettings["Useremailid"]);
                            objbase.waitforwire();

                            IWebElement elementPhone = driver.FindElement(By.Id("contentBody_gvUserList_txtPhone"));
                            elementPhone.SendKeys(ConfigurationSettings.AppSettings["Userphoneno"]);
                            objbase.waitforwire();

                            IWebElement elementActive = driver.FindElement(By.Id("contentBody_gvUserList_chkIsActive"));
                            bool resultcheckboxactive = elementActive.Displayed;
                            objbase.waitforwire();
                            if(resultcheckboxactive==true)
                            {
                                executor.ExecuteScript("arguments[0].click();", elementActive);
                                objbase.waitforwire();
                            }
                            // elementuserid.Clear();
                            
                            IWebElement elementsaveuser = driver.FindElement(By.Id("contentBody_btnAddUser"));
                            objbase.waitforwire();
                            executor.ExecuteScript("arguments[0].click();", elementsaveuser);
                            objbase.waitforPageload();

                            //Handling alert post adding user

                            IAlert altuser = driver.SwitchTo().Alert();
                            string useralert = altuser.Text;
                            Console.WriteLine("New User Alert: " + useralert);
                            altuser.Accept();
                            objbase.waitforPageload();

                            // User Entititlements

                            objbase.waitforPageload();
                            var elementAdminmenuforuserentitle = driver.FindElement(By.XPath("//*[@id='PEMenu_4779']"));
                            objbase.waitforPageload();
                            executor.ExecuteScript("arguments[0].click();", elementAdminmenuforuserentitle);
                            objbase.waitforPageload();

                            var elementAdminmenuUserEntitlements = driver.FindElement(By.XPath("//*[@id='PEMenu_4985']"));
                            objbase.waitforPageload();
                            executor.ExecuteScript("arguments[0].click();", elementAdminmenuUserEntitlements);
                            objbase.waitforPageload();

                            IWebElement elementuser = driver.FindElement(By.Id("contentBody_ddlUsers"));
                           
                            SelectElement selectuser = new SelectElement(elementuser);
                            selectuser.SelectByText(ConfigurationSettings.AppSettings["Ddluser"]);
                            objbase.waitforPageload();
                            
                            IWebElement elementhighvalueapprovalgroup = driver.FindElement(By.Id("contentBody_dlRoleGroupMembership_chkRoleGroup_0"));
                            objbase.waitforPageload();
                            executor.ExecuteScript("arguments[0].click();", elementhighvalueapprovalgroup);
                            objbase.waitforPageload();

                            IWebElement btnsave = driver.FindElement(By.Id("contentBody_btnSave"));
                            executor.ExecuteScript("arguments[0].click();", btnsave);
                            objbase.waitforPageload();

                        }

                        //Log off

                        var elementlogff = driver.FindElement(By.XPath("//*[@id='PEMenu_4309']"));
                        objbase.waitforPageload();
                        executor.ExecuteScript("arguments[0].click();", elementlogff);
                        objbase.waitforPageload();

                    }
                    else
                    {
                        /*IWebElement eletblusers = driver.FindElement(By.Id("ctl00_Main_UserlistTbl");
                       Navigator.Table().GetById("ctl00_Main_UserlistTbl").GetByLinkText("CME, CashMgmtReview (E)").DoubleClick();
                       Navigator.WaitForSeconds(10);
                       Navigator.Table().GetById("ctl00_Main_ApplistTbl").GetByLinkText("Cash Management Engine").DoubleClick();
                       Navigator.WaitForSeconds(10);*/
                    }

                }
                catch (Exception excme)
                {

                    Console.WriteLine("Cash Mangement Engine:" + excme.Message.ToString());
                    driver.Quit();

                }
                
            }

          

    }
}
