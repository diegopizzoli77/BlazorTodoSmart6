
using Blazored.LocalStorage;
using BlazorTodoSmart.Models;
using BlazorTodoSmart.MVVM;
using BlazorTodoSmart.MVVM.Interface;
using BlazorTodoSmart.Service;
using BlazorTodoSmart.Service.Interface;
using BlazorTodoSmart6.Client;
using Client.CommonService.IndexedDB;
using Client.CommonService.Interface;
using Client.CommonService.Navigation;
using DnetIndexedDb;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTelerikBlazor();


builder.Services.AddSingleton<PageHistoryState>();

/* Register service for communication */
builder.Services.AddIndexedDbDatabase<IndexDBContext<ActivityItem>>(o => { o.UseDatabase(new ActivityOffLineDB()); });


/* Register service */

builder.Services.AddTransient<IRepository<ActivityItem>, IndexDBContext<ActivityItem>>();

builder.Services.AddTransient<IActivityItemService, ActivityItemService>();
builder.Services.AddTransient<IActivitySummaryService, ActivitySummaryService>();
builder.Services.AddTransient<IActivityMainService, ActivityMainService>();

/*Register VM */
builder.Services.AddTransient<IActivitySummaryViewModel, ActivitySummaryViewModel>();
builder.Services.AddTransient<ActivitySummaryViewModel>();

builder.Services.AddTransient<IActivityFormViewModel, ActivityFormViewModel>();
builder.Services.AddTransient<ActivityFormViewModel>();

builder.Services.AddTransient<IActivityListViewModel, ActivityListViewModel>();
builder.Services.AddTransient<ActivityListViewModel>();

builder.Services.AddTransient<IListActivityPageViewModel, ListActivityPageViewModel>();
builder.Services.AddTransient<ListActivityPageViewModel>();

builder.Services.AddTransient<IActivityCalendarViewModel, ActivityCalendarViewModel>();
builder.Services.AddTransient<ActivityCalendarViewModel>();

await builder.Build().RunAsync();

