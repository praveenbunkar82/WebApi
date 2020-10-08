using AutoMapper;
using Egras.Entities;
using Egras.Entities.DTO;
using Egras.LoggerService;
using Egras.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgrasWebAPI.API.Controllers.MenuControllers
{
    [Route("api/menu")]
    public class MenuController : Controller
    {
        IRepository<Menu> _menuRepository;
        private ILoggerManager _logger;
        private IMapper _mapper;
        public MenuController(IRepository<Menu> menuRepository, ILoggerManager logger, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var menu = await _menuRepository.Get();
                _logger.LogInfo("Return all the menus from the storage");

                var menuResult = _mapper.Map<IEnumerable<MenuDto>>(menu);
                return Ok(menuResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong with inside Get action: {ex.Message}");
                return BadRequest(new ResponseMessages { Message = "Internal server error", status = "500" });
            }
        }

        [HttpGet("MenuByUserId/{userid}")]
        public async Task<IActionResult> GetMenuByUserId(int userid)
        {
            try
            {
                if (userid == 0)
                {
                    _logger.LogError($"userid: {userid}, Can not be zero or null.");
                    return BadRequest(new ResponseMessages { Message = "UserId can not be zero or null", status = "400" });
                }
                var menu = await _menuRepository.Get(userid);

                if (!menu.Any())
                {
                    _logger.LogError($"Menu with userid: {userid}, hasn't been found in db.");
                    return NotFound(new ResponseMessages { Message = "Not Found", status = "404" });
                }
                else
                {
                    _logger.LogInfo($"Fetching all the menus by userid : {userid} from the storage");
                    var menuResult = _mapper.Map<IEnumerable<MenuDto>>(menu);
                    return Ok(menuResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong with userid : {userid} inside GetMenuByUserId action: {ex.Message}");
                return BadRequest(new ResponseMessages { Message = "Internal server error", status = "500" });
            }
        }

        [HttpGet("{menuId}", Name = "MenuById")]
        public async Task<IActionResult> GetMenu(int menuId)
        {
            try
            {
                if (menuId == 0)
                {
                    _logger.LogError($"menuId: {menuId}, Can not be zero or null.");
                    return BadRequest(new ResponseMessages { Message = "menuId can not be zero or null", status = "400" });
                }
                var menu = await _menuRepository.GetItem(menuId);
                if (!menu.Any())
                {
                    _logger.LogError($"Menu with menuid: {menuId}, hasn't been found in db.");
                    return NotFound(new ResponseMessages { Message = "Not Found", status = "404" });
                }
                else
                {
                    _logger.LogInfo($"Fetching the menus by menuId : {menuId} from the storage");
                    var menuResult = _mapper.Map<IEnumerable<MenuDto>>(menu);
                    return Ok(menuResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong with menuid : {menuId} inside GetMenu action: {ex.Message}");
                return BadRequest(new ResponseMessages { Message = "Internal server error", status = "500" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMenu([FromBody] Menu menu)
        {
            try
            {
                if (menu == null)
                {
                    _logger.LogError($"menu object Can not be zero or null.");
                    return BadRequest(new ResponseMessages { Message = "menu object is null", status = "400" });
                }
                //if (!ModelState.IsValid)
                //{
                //    _logger.LogError($"Invalid model object During model creation");
                //    return BadRequest(ModelState);
                //    //return BadRequest(ModelState);
                //}
                var menuEntity = _mapper.Map<Menu>(menu);

                var menuVal = await _menuRepository.Add(menuEntity);

                if (menuVal != 0)
                {
                    var createdMenu = _mapper.Map<MenuDto>(menuEntity);

                    _logger.LogInfo($"New Created menu as menuId : {createdMenu.MenuId} from the storage");

                    return CreatedAtRoute("MenuById", new { menuId = createdMenu.MenuId }, createdMenu);
                    //return StatusCode((int)HttpStatusCode.OK, Json("Menu Created Successfully !!!"));  //Ok(val);
                }
                else
                {
                    return BadRequest(new ResponseMessages { Message = "Menu Not Created !!!", status = "400" });
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the Create Menu action: {ex}");
                return BadRequest(new ResponseMessages { Message = "Internal server error", status = "500" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenu([FromBody] Menu menu)
        {
            try
            {
                if (menu == null)
                {
                    _logger.LogError($"menu object Can not be zero or null.");
                    return BadRequest(new ResponseMessages { Message = "menu object is null", status = "400" });
                }
                //if (!ModelState.IsValid)
                //{
                //    _logger.LogError($"Invalid model object During model creation");
                //    return BadRequest(new ResponseMessages { Message = "Invalid model object", status = "500" });
                //}
                var menuEntity = _mapper.Map<Menu>(menu);

                var menuVal = await _menuRepository.Update(menuEntity);
                if (menuVal != 0)
                {
                    var updatedMenu = _mapper.Map<MenuDto>(menuEntity);

                    _logger.LogInfo($"Update menu by menuId : {updatedMenu.MenuId} from the storage");

                    return CreatedAtRoute("MenuById", new { menuId = updatedMenu.MenuId }, updatedMenu);
                }
                else
                {
                    return BadRequest(new ResponseMessages { Message = "Menu Not Updated !!!", status = "500" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the UpdateMenu action: {ex}");
                return BadRequest(new ResponseMessages { Message = "Internal server error", status = "500" });
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int id, int deletedByUserId)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError($"menuId: {id}, Can not be zero or null.");
                    return BadRequest(new ResponseMessages { Message = "menuId can not be zero or null", status = "400" });
                }
                var menu = await _menuRepository.Delete(id);
                if (menu == 0)
                {
                    _logger.LogError($"Menu with menuid: {id}, hasn't been found in db.");
                    return NotFound(new ResponseMessages { Message = "Not Found", status = "404" });
                }
                else
                {
                    _logger.LogInfo($"Deleted the menu by menuId : {id} by userid:{deletedByUserId} from the storage");
                    return Ok(new ResponseMessages { Message = "Successully Deleted!!", status = "200" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the Delete action: {ex}");
                return BadRequest(new ResponseMessages { Message = "Internal server error", status = "500" });
            }
        }
    }

}



//OK => returns the 200 status code
//NotFound => returns the 404 status code
//BadRequest => returns the 400 status code
//NoContent => returns the 204 status code
//Created, CreatedAtRoute, CreatedAtAction => returns the 201 status code
//Unauthorized => returns the 401 status code
//Forbid => returns the 403 status code
//StatusCode => returns the status code we provide as input