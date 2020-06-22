using Shoes.BLL;
using Shoes.Common.Rsp;
using Shoes.Common.BLL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shoes.BLL
{
    using DAL;
    using DAL.Models;
    using Shoes.Common.Req;

    public class EmployeesSvc : GenericSvc<EmployeesRep, Employees>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="m">The model</param>
        /// <returns>Return the result</returns>
        public override SingleRsp Update(Employees m)
        {
            var res = new SingleRsp();

            var m1 = m.EmployeeId > 0 ? _rep.Read(m.EmployeeId) : _rep.Read(m.LastName);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public EmployeesSvc() { }


        #endregion
        public object SearchEmployees(string keyword, int page, int size)
        {
            var pro = All.Where(x => x.FirstName.Contains(keyword));
            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalPage = ((total) % size) == 0 ? (total / size) : ((int)(total / size) + 1);
            var data = pro.OrderBy(x => x.EmployeeId).Skip(offset).Take(size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPage = totalPage,
                Size = size,
                Page = page,
            };
            return res;
        }

        public SingleRsp CreateEmployees(CreateEmployeesReq emp)
        {
            var res = new SingleRsp();
            Employees employees = new Employees();
            //employees.EmployeeId = emp.EmployeeId;
            employees.FirstName = emp.FirstName;
            employees.LastName = emp.LastName;
            employees.Country = emp.Country;
            res = _rep.CreateEmployees(employees);
            return res;
        }

        public SingleRsp UpdateEmployees(EmployeesReq emp)
        {
            var res = new SingleRsp();
            Employees employees = new Employees();
            employees = _rep.Read(emp.EmployeeId);
            employees.FirstName = emp.FirstName;
            employees.LastName = emp.LastName;
            employees.Country = emp.Country;
            res = _rep.UpdateEmployees(employees);
            return res;
        }
        public SingleRsp DeleteEmployees(int id)
        {
            var res = new SingleRsp();
            try
            {
                res.Data = _rep.RemoveEmployees(id);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }
    }
}