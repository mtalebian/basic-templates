﻿using Common;
using Forms.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Forms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [EnableCors("react")]
    public class GridsController : ControllerBase
    {
        private readonly IGridService service;

        public GridsController(IGridService formService)
        {
            this.service = formService;
        }


        [HttpPost("get-groups")]
        public Response<GroupInfoDTO[]> GetGroups(string projectId)
        {
            var groups = service.GetAllGroups(projectId);
            var result = new List<GroupInfoDTO>();
            foreach (var g in groups)
            {
                var dto = g.MapTo<GroupInfoDTO>();
                dto.Items = service.GetGrids(g.ProjectId, g.Id).MapTo<GroupItemDTO>().ToArray();
                result.Add(dto);
            }
            return new Response<GroupInfoDTO[]>(result.ToArray());
        }

        [HttpPost("browse-table")]
        public Response<BrowseTableDTO> BrowseTable(string projectId, string name)
        {
            var filters = (Dictionary<string, object[]>)null;
            var table = service.GetGrid(projectId, name);
            var columns = service.GetGridColumns(table.ProjectId, table.Id);
            var data = service.ExecuteSelect(table, columns, filters);

            var result = new BrowseTableDTO();
            result.Schema = table.MapTo<GridDTO>();
            result.Schema.DataColumns = columns.MapTo<GridColumnDTO>();
            result.Data = data.ToJSON();
            return new Response<BrowseTableDTO>(result);
        }

        [HttpPost("exec-table-action")]
        public Response ExecTableAction(string projectId, [FromBody] GridActionDTO dto)
        {
            switch (dto.Name)
            {
                case "insert":
                    service.ExecuteInsert(projectId, dto.GridId, dto.Values);
                    break;

                case "update":
                    service.ExecuteUpdate(projectId, dto.GridId, dto.Values);
                    break;

                case "delete":
                    service.ExecuteDelete(projectId, dto.GridId, dto.Values);
                    break;

                default: return new Response("Invalid action!");
            }
            return new Response();
        }

    }
}