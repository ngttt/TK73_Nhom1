using Shoes.Common.DAL;
using System.Linq;

namespace Shoes.DAL
{
    using Models;
    public class SuppliersRep : GenericRep<quanlybangiayContext, Suppliers>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Suppliers Read(int id)
        {
            var res = All.FirstOrDefault(p => p.SuppliersId == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.SuppliersId == id);
            m = base.Delete(m); //TODO
            return m.SuppliersId;
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>

        #endregion
    }
}