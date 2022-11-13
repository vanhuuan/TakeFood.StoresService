﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TakeFood.StoreService.ViewModel.Dtos.Store;

public class GetPagingStoreDto
{
    [Required]
    [FromQuery]
    public int PageNumber { get; set; }
    [Required]
    public int PageSize { get; set; }
    /// <summary>
    /// Code/Name
    /// </summary>
    [Required]
    [FromQuery]
    public String QueryType { get; set; }
    /// <summary>
    /// Text to search
    /// </summary>
    [FromQuery]
    [Required]
    public String QueryString { get; set; }
    /// <summary>
    /// CreateDate StartDate EndDate Name Code
    /// </summary>
    [Required]
    [FromQuery]
    public String SortBy { get; set; }
    /// <summary>
    /// Desc Asc
    /// </summary>
    [Required]
    [FromQuery]
    public String SortType { get; set; }
}
