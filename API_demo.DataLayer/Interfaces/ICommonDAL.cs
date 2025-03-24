namespace API_demo.DataLayers.Interfaces
{
    /// <summary>
    /// Định nghĩa các phép lấy dữ liệu thường trên các bảng đơn như (Customers, Categories,...)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommonDAL<T> where T : class
    {
        /// <summary>
        /// Lấy danh sách không có điều kiện
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> List();
        /// <summary>
        /// Lấy về một object hoặc một list theo từ khoá tìm kiếm
        /// </summary>
        /// <param name="SearchValue"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> Search(string SearchValue);
        /// <summary>
        /// Thêm một bảng ghi vào cơ sở dữ liệu và trả về id của bảng ghi đó
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<int> Add(T data);
        /// <summary>
        /// Xoá một bản ghi trong cơ sở dữ liệu thông qua id của bảng ghi
        /// </summary>
        /// <param name="id">in của bản ghi muốn xoá</param>
        /// <returns></returns>
        Task<bool> Delete(int id);
        /// <summary>
        /// Cập nhật dữ liệu của bảng ghi
        /// </summary>
        /// <param name="data">dữ liệu vào</param>
        /// <returns></returns>
        Task<bool> Update(T data);
    }
}
