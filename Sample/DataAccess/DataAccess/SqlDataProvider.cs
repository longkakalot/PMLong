using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DataAccess
{
    public class SqlDataProvider : DataProvider
    {
        private string _ConnectionString;
        public SqlDataProvider(string connectionStringName)
        {
            //Lấy chuỗi kết nối từ web config hoặc app config
            _ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

        protected SqlConnection GetSqlConnection()
        {
            try
            {
                return new SqlConnection(_ConnectionString);
            }
            catch
            {
                throw new Exception("SqlConnection");
            }
        }

        public override int PostAdd(Post post)
        {
            //1. Tạo đối tượng SqlConnection
            using (SqlConnection cnn = GetSqlConnection())
            {
                // 2. Tạo đối tượng SqlCommand
                SqlCommand cmd = cnn.CreateCommand();
                // 2.1. Đặt loại command là SP và tên thủ tục
                cmd.CommandType = CommandType.StoredProcedure;
                //Truyền tên của SP
                cmd.CommandText = "Post_Add";

                //2.2. Truyền tên, kiểu dữ liệu và giá trị tham số
                // Tuong ứng với phần PostID output trong SP
                // Do cột PostID tự tăng nên không cần truyền giá trị
                cmd.Parameters.Add("@PostID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 50).Value = post.Title;
                cmd.Parameters.Add("@Body", SqlDbType.NVarChar, 4000).Value = post.Body;
                //Kiểm tra kiểu dữ liệu Nullable, kiểm tra HasValue
                if (post.Publish.HasValue)
                    cmd.Parameters.Add("@Publish", SqlDbType.DateTime).Value = post.Publish.Value;
                else
                    cmd.Parameters.Add("@Publish", SqlDbType.DateTime).Value = DBNull.Value;

                //3. Mở kết nối
                cnn.Open();

                //Thực hiện thêm record vào với các tham số truyền vào
                //Kết quả hàm ExcuteNonQuery là số record được thêm vào CSDL
                // > 0 : thành công - < 0: thất bại
                //4. Gọi hàm ExecuteNonQuery
                int rs = cmd.ExecuteNonQuery();
                if (rs > 0)
                {
                    //5. Lấy giá trị id tự tăng của record vừa thêm vào
                    return (int)cmd.Parameters["@PostID"].Value;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}