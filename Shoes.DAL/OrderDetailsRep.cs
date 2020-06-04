using Shoes.Common.DAL;
using System.Linq;

namespace Shoes.DAL
{
    using Models;
    public class OrderDetailsRep : GenericRep<quanlybangiayContext, OderDetails>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public OderDetails Read1(int id)
        {
            var res = All.FirstOrDefault(p => p.OrderId == id);
            return res;
        }

        public OderDetails Read2(int id)
        {
            var res = All.FirstOrDefault(p => p.ProductId == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove1(int id)
        {
            var m = base.All.First(i => i.OrderId == id);
            m = base.Delete(m); //TODO
            return m.OrderId;
        }

        public int Remove2(int id)
        {
            var m = base.All.First(i => i.ProductId == id);
            m = base.Delete(m); //TODO
            return m.ProductId;
        }
        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>

        #endregion
    }
}