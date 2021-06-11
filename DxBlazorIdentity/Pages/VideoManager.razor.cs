using DevExpress.Blazor;
using DxBlazorIdentity.Models;
using DxBlazorIdentity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DxBlazorIdentity.Pages
{
    [AllowAnonymous]
    public class VideoManagerBase : ComponentBase
    {
        [Inject] IJSRuntime JsRuntime { get; set; }
        public List<Video> Videos { get; set; }
        public DxDataGrid<Video> MyGrid;

        private VideoService VideoService;

        protected override async Task OnInitializedAsync()
        {

            VideoService = new VideoService();
            await BindGrid();
        }
        private async Task BindGrid(bool refreshGrid = false)
        {
            Videos =  VideoService.ListAsync();
            if (refreshGrid)
            {
                await InvokeAsync(StateHasChanged);
            }
        }

        public Task OnInitNewRow(Dictionary<string, object> values)
        {
            values.Add("VideoDate", DateTime.Now.Date);
            return Task.CompletedTask;
        }
        public async Task OnRowInserting(IDictionary<string, object> newValues)
        {
            //await VideoService.AddAsync(UpdateItem<Video>(new Video(), newValues));

            await BindGrid(true);
        }
        public async Task OnRowUpdating(Video dataItem, IDictionary<string, object> newValues)
        {
            //await VideoService.UpdateAsync(UpdateItem<Video>(dataItem, newValues));
        }
        public async Task OnRowDeleting(Video dataItem)
        {
            bool isConfirmed = await JsRuntime.InvokeAsync<bool>("confirmDelete");

            if (isConfirmed && dataItem != null)
            {
                //await VideoService.DeleteAsync(dataItem);
                await BindGrid(true);
            }
        }

        private T UpdateItem<T>(T item, IDictionary<string, object> newValues) where T : new()
        {
            foreach (var field in newValues.Keys)
            {
                item.GetType().GetProperty(field).SetValue(item, newValues[field]);
            }
            return item;
        }
    }
}
