namespace API_demo.DataLayers.Interfaces
{
    public interface ISimpleSelectDAL<T> where T : class
    {
        /// <summary>
        /// Select toàn bộ dữ liệu của bảng
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> List();
    }
}
