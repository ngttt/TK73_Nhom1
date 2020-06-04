using Shoes.Common.DAL;
using System.Linq;

namespace Shoes.DAL
{
    using Models;
    public class EmployeesRep : GenericRep<quanlybangiayContext, Employees>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Employees Read(int id)
        {
            var res = All.FirstOrDefault(p => p.EmployeeId == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.EmployeeId == id);
            m = base.Delete(m); //TODO
            return m.EmployeeId;
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>

        #endregion
    }
}