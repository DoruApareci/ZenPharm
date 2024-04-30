﻿using ZenPharm.DAL.Models;

namespace ZenPharm.Web.Models;

public class AdminProductListViewModel
{
    public List<Product> Products { get; set; } = [];

    public int TotalPages { get; set; }
    public int PageSize { get; } = 10;
    public int CurrentPage { get; set; } = 1;
    public int Step { get; } = 5;
    public int ItemsAroundCurrentPage = 2;
    public int FromPage
    {
        get => ((CurrentPage - ItemsAroundCurrentPage) > 1) ? CurrentPage - ItemsAroundCurrentPage : 1;
    }
    public int ToPage
    {
        get => TotalPages > Step ? CurrentPage + ItemsAroundCurrentPage : TotalPages;
    }
}
