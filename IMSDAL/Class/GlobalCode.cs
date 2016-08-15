using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing.Design;
using System.Xml;
using System.Globalization;
using System.Data;
using System.Reflection;


namespace IMSDAL.Class
{
    public class GlobalCode
    {

        public const string DateTimeFormat = "MM/dd/yyyy HH:mm:ss:fff";
        public const string UserCultureInfo = "en-US";

        //public object createXMl(List<Vendor> vendor)
        //{
        //    object xml = new object();

        //    string appPath = AppDomain.CurrentDomain.BaseDirectory + @"Extract\";
        //    XmlTextWriter writer = null;
        //    if (vendor.Count > 0)
        //    {

        //        writer = new XmlTextWriter(appPath + "InvoiceNumber_" + vendor[0].VendorNumber + "_" + DateTime.Now.Date.ToString("yyyy-MM-dd h mm tt") + ".xml", System.Text.Encoding.UTF8);
        //        writer.WriteStartDocument(true);
        //        writer.Formatting = Formatting.Indented;
        //        writer.Indentation = 2;
        //        writer.WriteStartElement("Vendors");
        //        for (var i = 0; i < vendor.Count; i++)
        //        {

        //            writer.WriteStartElement("Vendor");
        //            writer.WriteAttributeString("VendorNumber", vendor[i].VendorNumber);
        //            writer.WriteStartElement("Invoices");

        //            if (vendor[i].InvoiceHeader.Count > 0)
        //            {
        //                var inHeader = vendor[i].InvoiceHeader;
        //                for (var iHeader = 0; iHeader < inHeader.Count; iHeader++)
        //                {
        //                    writer.WriteStartElement("Invoice");
        //                    writer.WriteStartElement("InvoiceHeader");
        //                    createNode("InvoiceNumber", inHeader[iHeader].InvoiceNumber, writer);
        //                    createNode("InvoiceDate", inHeader[iHeader].InvoiceDate, writer);
        //                    createNode("PortNumber", inHeader[iHeader].PortNumber, writer);
        //                    createNode("ShipNumber", inHeader[iHeader].ShipNumber, writer);
        //                    createNode("BusinessUnitCode", inHeader[iHeader].BusinessUnitCode, writer);
        //                    writer.WriteEndElement();

        //                    if (inHeader[iHeader].InvoiceDetail.Count > 0)
        //                    {
        //                        var indetail = inHeader[iHeader].InvoiceDetail;
        //                        writer.WriteStartElement("InvoiceDetails");
        //                        for (var iDet = 0; iDet < indetail.Count; iDet++)
        //                        {

        //                            writer.WriteStartElement("InvoiceDetail");
        //                            createNode("ExpenseTypeCode", indetail[iDet].ExpenseTypeCode, writer);
        //                            createNode("Quantity", indetail[iDet].Quantity, writer);
        //                            createNode("UnitCost", indetail[iDet].UnitCost, writer);
        //                            createNode("CurrencyCode", indetail[iDet].CurrencyCode, writer);
        //                            createNode("TotalCost", indetail[iDet].TotalCost, writer);
        //                            createNode("Comment", indetail[iDet].Comment, writer);
        //                            createNode("EmployeeNumber", indetail[iDet].EmployeeNumber, writer);
        //                            createNode("CrewServiceStartDate", indetail[iDet].CrewServiceStartDate, writer);
        //                            createNode("CrewServiceEndDate", indetail[iDet].CrewServiceEndDate, writer);
        //                            createNode("UnitOfMeasureType", indetail[iDet].UnitCost, writer);
        //                            createNode("TripNumber", indetail[iDet].TripNumber, writer);

        //                            writer.WriteEndElement();
        //                        }
        //                        writer.WriteEndElement();
        //                    }

        //                    writer.WriteEndElement();
        //                }
        //            }

        //            writer.WriteEndElement();
        //            writer.WriteEndElement();

        //        }

        //        writer.WriteEndDocument();
        //        writer.Flush();
        //        writer.Close();

        //    }
        //    return writer;


        //}

        private void createNode(string elementNode, string elementValue, XmlTextWriter writer)
        {
            writer.WriteStartElement(elementNode);
            writer.WriteString(elementValue);
            writer.WriteEndElement();
        }



        //public object createXMlNew(List<Vendor> vendor)
        //{
        //    object xml = new object();
        //    XmlWriterSettings settings = new XmlWriterSettings();
        //    if (vendor.Count > 0)
        //    {
        //        string appPath = AppDomain.CurrentDomain.BaseDirectory + @"Extract\";


        //        settings.Indent = true;
        //        settings.IndentChars = ("    ");
        //        settings.CloseOutput = true;
        //        settings.OmitXmlDeclaration = true;
        //        using (XmlWriter writer = XmlWriter.Create(appPath + "InvoiceNumber_" + vendor[0].VendorNumber + "_" + DateTime.Now.Date.ToString("yyyy-MM-dd h mm tt") + ".xml", settings))
        //        {



        //            writer.WriteStartElement("Vendors");
        //            for (var i = 0; i < vendor.Count; i++)
        //            {

        //                writer.WriteStartElement("Vendor");
        //                writer.WriteAttributeString("VendorNumber", vendor[i].VendorNumber);
        //                writer.WriteStartElement("Invoices");

        //                if (vendor[i].InvoiceHeader.Count > 0)
        //                {
        //                    var inHeader = vendor[i].InvoiceHeader;
        //                    for (var iHeader = 0; iHeader < inHeader.Count; iHeader++)
        //                    {
        //                        writer.WriteStartElement("Invoice");
        //                        writer.WriteStartElement("InvoiceHeader");
        //                        createNodeNew("InvoiceNumber", inHeader[iHeader].InvoiceNumber, writer);
        //                        createNodeNew("InvoiceDate", inHeader[iHeader].InvoiceDate, writer);
        //                        createNodeNew("PortNumber", inHeader[iHeader].PortNumber, writer);
        //                        createNodeNew("ShipNumber", inHeader[iHeader].ShipNumber, writer);
        //                        createNodeNew("BusinessUnitCode", inHeader[iHeader].BusinessUnitCode, writer);
        //                        writer.WriteEndElement();

        //                        if (inHeader[iHeader].InvoiceDetail.Count > 0)
        //                        {
        //                            var indetail = inHeader[iHeader].InvoiceDetail;
        //                            writer.WriteStartElement("InvoiceDetails");
        //                            for (var iDet = 0; iDet < indetail.Count; iDet++)
        //                            {

        //                                writer.WriteStartElement("InvoiceDetail");
        //                                createNodeNew("ExpenseTypeCode", indetail[iDet].ExpenseTypeCode, writer);
        //                                createNodeNew("Quantity", indetail[iDet].Quantity, writer);
        //                                createNodeNew("UnitCost", indetail[iDet].UnitCost, writer);
        //                                createNodeNew("CurrencyCode", indetail[iDet].CurrencyCode, writer);
        //                                createNodeNew("TotalCost", indetail[iDet].TotalCost, writer);
        //                                createNodeNew("Comment", indetail[iDet].Comment, writer);
        //                                createNodeNew("EmployeeNumber", indetail[iDet].EmployeeNumber, writer);
        //                                createNodeNew("CrewServiceStartDate", indetail[iDet].CrewServiceStartDate, writer);
        //                                createNodeNew("CrewServiceEndDate", indetail[iDet].CrewServiceEndDate, writer);
        //                                createNodeNew("UnitOfMeasureType", indetail[iDet].UnitCost, writer);
        //                                createNodeNew("TripNumber", indetail[iDet].TripNumber, writer);

        //                                writer.WriteEndElement();
        //                            }
        //                            writer.WriteEndElement();
        //                        }

        //                        writer.WriteEndElement();
        //                    }
        //                }

        //                writer.WriteEndElement();
        //                writer.WriteEndElement();

        //            }

        //            writer.WriteEndDocument();
        //            writer.Flush();
        //            writer.Close();









        //        }




        //    }
        //    return settings;


        //}

        private void createNodeNew(string elementNode, string elementValue, XmlWriter writer)
        {
            writer.WriteStartElement(elementNode);
            writer.WriteString(elementValue);
            writer.WriteEndElement();
        }



        public long Field2Long(object sender)
        {
            long vLong = 0;
            try
            {
                if (sender != null)
                {
                    switch (sender.GetType().Name.ToString())
                    {

                        //case "TextBox":
                        //    TextBox textbox = (TextBox)sender;
                        //    vLong = Convert.ToInt64(textbox.Text.ToString());
                        //    break;
                        case "String":
                            string sType = (string)sender;
                            vLong = Convert.ToInt64(sType.ToString());
                            break;
                        default:
                            vLong = Convert.ToInt64(sender.ToString());
                            break;

                    }
                }
                return vLong;
            }
            catch
            {
                return 0;
            }
        }
        public Int32 Field2Int(object sender)
        {
            Int32 vInt = 0;
            try
            {
                if (sender != null)
                {
                    switch (sender.GetType().Name.ToString())
                    {

                        //case "TextBox":
                        //    TextBox textbox = (TextBox)sender;
                        //    vInt = Convert.ToInt32(textbox.Text.ToString());
                        //    break;
                        case "String":
                            string sType = (string)sender;
                            vInt = Convert.ToInt32(sType.ToString());
                            break;
                        default:
                            vInt = Convert.ToInt32(sender.ToString());
                            break;
                    }
                }
                return vInt;
            }
            catch
            {
                return 0;
            }
        }

        public float Field2Float(object sender)
        {
            float vInt = 0;
            try
            {
                if (sender != null)
                {
                    switch (sender.GetType().Name.ToString())
                    {

                        //case "TextBox":
                        //    TextBox textbox = (TextBox)sender;
                        //    vInt = Convert.ToSingle(textbox.Text.ToString());
                        //    break;
                        case "String":
                            string sType = (string)sender;
                            vInt = Convert.ToSingle(sType.ToString());
                            break;
                        default:
                            vInt = Convert.ToSingle(sender.ToString());
                            break;
                    }
                }
                return vInt;
            }
            catch
            {
                return 0;
            }
        }


        public Int16 Field2TinyInt(object sender)
        {
            Int16 vInt = 0;
            try
            {
                if (sender != null)
                {
                    switch (sender.GetType().Name.ToString())
                    {
                        //case "TextBox":
                        //    TextBox textbox = (TextBox)sender;
                        //    vInt = Convert.ToInt16(textbox.Text.ToString());
                        //    break;
                        case "String":
                            String SType = (String)sender;
                            vInt = Convert.ToInt16(SType.ToString());
                            break;
                        default:
                            vInt = Convert.ToInt16(sender.ToString());
                            break;
                    }
                }
                return vInt;
            }
            catch
            {
                return 0;
            }
        }

        public bool Field2Bool(object sender)
        {
            bool vbool = false;
            try
            {
                if (sender != null)
                {
                    switch (sender.GetType().ToString())
                    {
                        //case "TextBox":
                        //    TextBox textbox = (TextBox)sender;
                        //    vbool = Convert.ToBoolean(textbox.Text.ToString());
                        //    break;
                        case "String":
                            String SType = (String)sender;
                            vbool = Convert.ToBoolean(SType.ToString());
                            break;
                        default:
                            vbool = Convert.ToBoolean(sender);
                            break;
                    }
                }
                return vbool;
            }
            catch
            {
                return false;
            }
        }


        public string Field2String(object sender)
        {
            try
            {
                if (sender != null)
                    return sender.ToString();
                else
                    return "";
            }
            catch
            {
                return "";
            }

        }




        /// <summary>
        /// Date Created:     03/02/2012
        /// Created By:       Josephine Gad
        /// (description)     Convert object to datetime
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static DateTime? Field2DateTime(object sender)
        {
            CultureInfo enCulture = new CultureInfo(UserCultureInfo);
            DateTime vDateTime = DateTime.Now;
            try
            {
                if (sender != null)
                {
                    switch (sender.GetType().Name.ToString())
                    {
                        //case "TextBox":
                        //    TextBox textbox = (TextBox)sender;
                        //    vDateTime = DateTime.Parse(textbox.Text.ToString(), enCulture);
                        //    break;
                        case "String":
                            String SType = (String)sender;
                            vDateTime = DateTime.Parse(SType.ToString(), enCulture);
                            break;
                        default:
                            vDateTime = DateTime.Parse(sender.ToString(), enCulture);
                            break;
                    }
                }
                return vDateTime;
            }
            catch
            {
                return null;
            }
        }






        /// <summary>
        /// Date Created:   02/01/2011
        /// Created By:     Josephine Gad
        /// (description)   Convert string to decimal with validation
        /// =============================================================
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public decimal Field2Decimal(object sender)
        {
            decimal vDec = 0;
            try
            {
                if (sender != null)
                {
                    switch (sender.GetType().Name.ToString())
                    {

                        //case "TextBox":
                        //    TextBox textbox = (TextBox)sender;
                        //    vDec = Convert.ToDecimal(textbox.Text.ToString());
                        //    break;
                        case "String":
                            string sType = (string)sender;
                            vDec = Convert.ToDecimal(sType.ToString());
                            break;
                        default:
                            vDec = Convert.ToDecimal(sender.ToString());
                            break;
                    }
                }
                return vDec;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// Date Created:   20/04/2012
        /// Created By:     Josephine Gad
        /// (description)   Convert string to double with validation
        /// =============================================================
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public double Field2Double(object sender)
        {
            double vDouble = 0;
            try
            {
                if (sender != null)
                {
                    switch (sender.GetType().Name.ToString())
                    {

                        //case "TextBox":
                        //    TextBox textbox = (TextBox)sender;
                        //    vDouble = Convert.ToDouble(textbox.Text.ToString());
                        //    break;
                        case "String":
                            string sType = (string)sender;
                            vDouble = Convert.ToDouble(sType.ToString());
                            break;
                        default:
                            vDouble = Convert.ToDouble(sender.ToString());
                            break;
                    }
                }
                return vDouble;
            }
            catch
            {
                return 0;
            }
        }



        public DateTime GetClientTime()
        {
            DateTime vLocalTime = DateTime.Now;

            TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById(TimeZone.CurrentTimeZone.StandardName);
            TimeZoneInfo local = TimeZoneInfo.Local;
            vLocalTime = TimeZoneInfo.ConvertTime(DateTime.Now, local, cst);

            TimeZoneInfo.ClearCachedData();
            try
            {
                return TimeZoneInfo.ConvertTime(DateTime.Now, local, cst);
            }
            catch
            {
                return vLocalTime;
            }
        }


        /// <summary>
        /// Author:       Muhallidin G Wali
        /// Date Created: 04/11/2013
        /// Description:  convert list to datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public DataTable getDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                //Type t = GetCoreType(prop.PropertyType);
                //tb.Columns.Add(prop.Name, t);
                tb.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                tb.Rows.Add(values);
            }
            return tb;
        }

        /// <summary>
        /// Author:       Muhallidin G Wali
        /// Date Created: 04/11/2013
        /// Description:  get item type
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Type GetCoreType(Type t)
        {
            if (t != null)
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        public static int GetdateDiff(DateTime dateFrom, DateTime dateTo)
        {
            int dateDiff = 0;
            System.DateTime dtdateFrom = new System.DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day, 12, 0, 0);
            System.DateTime dtdateTo = new System.DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 12, 0, 0);

            System.TimeSpan diffResult = dtdateTo - dtdateFrom;

            System.TimeSpan diffResults = dateTo - dateFrom;


            //TimeSpan GiveTheTimeOfTheDay = dateFrom.Date - dateTo.Date;
            dateDiff = int.Parse(diffResult.Days.ToString());

            try
            {
                return dateDiff;
            }
            catch
            {
                return 0;
            }
        }



    }
}
