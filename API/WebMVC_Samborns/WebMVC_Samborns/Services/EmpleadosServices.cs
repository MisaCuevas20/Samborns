using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebMVC_Samborns.Models.Entities;

namespace WebMVC_Samborns.Services
{
    public class EmpleadosService
    {
        private readonly HttpClient _httpClient;
        private readonly string apiUrl = "http://localhost:5164/api/Empleados";

        private readonly AreaService _areaService;
        public EmpleadosService(HttpClient httpClient, AreaService areaService)
        {
            _httpClient = httpClient;
            _areaService = areaService;
        }

        // Obtener todos los empleados
        public async Task<List<Empleados>?> GetEmpleadosAsync()
        {
            var response = await _httpClient.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Empleados>>(data);
        }


        // Obtener un empleado por ID
        public async Task<Empleados?> GetEmpleadoByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{apiUrl}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Empleados>(data);
        }

        // Crear un nuevo empleado
        public async Task<bool> CreateEmpleadoAsync(Empleados empleado)
        {
            var json = JsonConvert.SerializeObject(empleado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiUrl, content);
            return response.IsSuccessStatusCode;
        }

        // Actualizar un empleado
        public async Task<bool> UpdateEmpleadoAsync(int id, Empleados empleado)
        {
            var json = JsonConvert.SerializeObject(empleado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{apiUrl}/{id}", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode} - {errorContent}");
                return false;
            }

            return true;
        }



        // Eliminar un empleado
        public async Task<bool> DeleteEmpleadoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{apiUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
