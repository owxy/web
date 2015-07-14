using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

    public class Filter
    {
        /// <summary>
        /// �Ƚ���������
        /// �Ƚ��Ƿ�Ϊ�գ��Ƿ����
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        protected static bool ColumnEqual(object A, object B)
        {
            if (A == DBNull.Value && B == DBNull.Value)
                return true;
            if (A == DBNull.Value && B == DBNull.Value)
                return false;
            return (A.Equals(B));
        }

        /// <summary>
        /// ���˵��ֶ��ظ�ֵ��������JSON��Ҫ���ַ������
        /// </summary>
        /// <param name="dataTable">��Ҫת����datatable</param>
        /// <param name="fieldName">�ֶ�����</param>
        /// <returns>{name:'value'},{name:'value'}</returns>
        public static string SelectDistinct(DataTable dataTable, string fieldName)
        {
            StringBuilder sb = new StringBuilder();
            int date=0;
            if (fieldName.ToLower().IndexOf("date")>-1)
                date = 1;
            else
                date = 0;
            bool rc = false;
            object lastValue = null;
            foreach (DataRow dr in dataTable.Select("", fieldName))
            {
                
                if (lastValue == null || !(ColumnEqual(lastValue, dr[fieldName])))
                {
                    lastValue = dr[fieldName];

                    if (lastValue != null)
                    {
                        if (rc)
                            sb.Append(",");
                        sb.Append("{name:'");
                        if (date==1)
                        sb.Append( Convert.ToDateTime(lastValue).ToShortDateString());
                        else
                        sb.Append(lastValue.ToString());
                        
                        sb.Append("'}");
                        rc = true;
                    }
                }
            }
            return sb.ToString();
        }
    }

