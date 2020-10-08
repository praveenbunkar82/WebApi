using Dapper;
using Egras.Entities;
using Egras.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Data.CommandType;

namespace Egras.Repository
{
    public class MenuRepository : BaseRepository, IRepository<Menu>
    {
        public async Task<int> Add(Menu menu)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MenuDesc", menu.MenuDesc);
                parameters.Add("@NavigationUrl", menu.NavigationUrl);
                parameters.Add("@MenuParentId", menu.MenuParentId);
                parameters.Add("@MenuSecured", menu.MenuSecured);
                parameters.Add("@ModuleId", menu.ModuleId);
                parameters.Add("@ObjectType", menu.ObjectType);
                parameters.Add("@OrderId", menu.OrderId);
                parameters.Add("@MenuEnable", menu.MenuEnable);
                parameters.Add("@MenuVisible", menu.MenuVisible);
                parameters.Add("@TransDate", menu.TransDate);
                parameters.Add("@UpdatedDate", menu.UpdatedDate);
                parameters.Add("@CreatedById", menu.CreatedById);
                parameters.Add("@UpdatedById", menu.UpdatedById);

                var val = await SqlMapper.ExecuteAsync(con, "AddMenu", param: parameters, commandType: StoredProcedure);
                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int menuId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@menuId", menuId);
                return await SqlMapper.ExecuteAsync(con, "DeleteMenu", param: parameters, commandType: StoredProcedure);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<IEnumerable<Menu>> Get()
        {
            try { 
            var menuList = await SqlMapper.QueryAsync<Menu>(con, "GetAllMenus", commandType: StoredProcedure);
            return menuList;
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<IEnumerable<Menu>> Get(int userid)
        {
            try { 
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userid", userid);
            var menuList = await SqlMapper.QueryAsync<Menu>(con, "GetAllMenusByUserId", parameters, commandType: StoredProcedure);
            return menuList;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<IEnumerable<Menu>> GetItem(int menuId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@menuId", menuId);
                var menu = await SqlMapper.QueryAsync<Menu>(con, "GetMenuById", parameters, commandType: StoredProcedure);
                return menu;
            }
            catch (Exception ex) { throw ex; }
        }

        //public async Task<IEnumerable<Menu>> Get(int menuId)
        //{
        //    DynamicParameters parameters = new DynamicParameters();
        //    parameters.Add("@menuId", menuId);
        //    var menuList = await SqlMapper.QueryAsync<Menu>(con, "GetMenuById", parameters, commandType: StoredProcedure);
        //    return menuList;
        //}
        //public Task<Menu> GetItem(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public  Menu GetItem(int menuId)
        //{
        //    try
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@menuId", menuId);
        //        return  SqlMapper.Query<Menu>((SqlConnection)con, "GetMenuById", parameters, commandType: StoredProcedure).FirstOrDefault();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task<int> Update(Menu menu)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MenuId", menu.MenuId);
                parameters.Add("@MenuDesc", menu.MenuDesc);
                parameters.Add("@NavigationUrl", menu.NavigationUrl);
                parameters.Add("@MenuParentId", menu.MenuParentId);
                parameters.Add("@MenuSecured", menu.MenuSecured);
                parameters.Add("@ModuleId", menu.ModuleId);
                parameters.Add("@ObjectType", menu.ObjectType);
                parameters.Add("@OrderId", menu.OrderId);
                parameters.Add("@MenuEnable", menu.MenuEnable);
                parameters.Add("@MenuVisible", menu.MenuVisible);
                parameters.Add("@TransDate", menu.TransDate);
                parameters.Add("@UpdatedDate", menu.UpdatedDate);
                parameters.Add("@CreatedById", menu.CreatedById);
                parameters.Add("@UpdatedById", menu.UpdatedById);

               return await SqlMapper.ExecuteAsync(con, "UpdateMenu", param: parameters, commandType: StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
