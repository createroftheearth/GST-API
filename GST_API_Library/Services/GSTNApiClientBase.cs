﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models;
using Newtonsoft.Json;
using Microsoft.Owin.Infrastructure;

namespace GST_API_Library.Services
{
    public abstract class GSTNApiClientBase : IDisposable
    {
        protected internal string path;
        protected internal string url2;
        //protected internal string url3;

        protected internal string gstin;

        TimeSpan timeout = TimeSpan.FromSeconds(100);
        public GSTNApiClientBase(string path, string gstin)
        {
            //Change on 14/03/2023
            //this.path = "/taxpayerapi/v1.0/authenticate";//path;
            this.path = path;

            this.gstin = gstin;
            // pathSub = "https://devapi.gst.gov.in/taxpayerapi/v2.1/returns/gstr1";
            //url2 = "https://devapi.gst.gov.in/taxpayerapi/v1.0/authenticate";//GSTNConstants.base_url + path;
            url2 = GSTNConstants.base_url + path;

        }
        public TimeSpan RequestTimeout
        {
            get { return timeout; }
            set { timeout = value; }
        }
        public string PrepareQueryString(string path, IDictionary<string, string> Params)
        {
            url2 = WebUtilities.AddQueryString(path, Params);
            return url2;
        }
        public string PrepareQueryString(IDictionary<string, string> Params)
        {
            return this.PrepareQueryString(GSTNConstants.base_url + path, Params);
        }
        //NOT USED
        public string PrepareQueryStringGSTR(IDictionary<string, string> Params)
        {
            var Abc = "/taxpayerapi/v1.1/returns";
            return this.PrepareQueryString((GSTNConstants.base_url + Abc).Replace("/gstr1", "").Replace("/gstr3b", "").Replace("/gstr2", ""), Params);
            //return this.PrepareQueryString((GSTNConstants.base_url + path).Replace("/gstr1", "/gstr1").Replace("/gstr3b", "").Replace("/gstr2", ""), Params);
        }
        #region "Async Methods"

        public async Task<GSTNResult<TOutput>> GetAsync<TOutput>()
        {
            using (var client = GetHttpClient())
            {
                //url2 to url3 amit

                System.Console.WriteLine("GET:" + url2);
                HttpResponseMessage response = await client.GetAsync(url2);
                return BuildResponse<TOutput>(response);
            }

        }

        public async Task<GSTNResult<TOutput>> PostAsync<TInput, TOutput>(TInput data)
        {
            using (var client = GetHttpClient())
            {
                System.Console.WriteLine("POST:" + url2);
                HttpResponseMessage response;
                if (typeof(TInput) == typeof(string))
                {
                    var content = new StringContent((string)(object)data, System.Text.Encoding.UTF8, "text/plain");
                    response = await client.PostAsync(url2, content);
                }
                else
                {
                // if(data)
                //--http://devapi.gstsystem.co.in/taxpayerapi/v0.3/returns/gstr1?gstin=33GSPTN0231G1ZM&action=RETFILE&ret_period=042017
                //Change by amit
                http://devapi.gstsystem.co.in/taxpayerapi/v2.2/returns/gstr1?gstin=33GSPTN0231G1ZM&action=RETFILE&ret_period=022023
                    response = await client.PostAsJsonAsync(url2, data);
                    //response = await client.PostAsJsonAsync(pathSub, data);
                }
                return BuildResponse<TOutput>(response);
            }

        }

        public async Task<GSTNResult<TOutput>> PutAsync<TInput, TOutput>(TInput data)
        {
            using (var client = GetHttpClient())
            {
                System.Console.WriteLine("PUT:" + url2);
                HttpResponseMessage response = await client.PutAsJsonAsync(url2, data);
                return BuildResponse<TOutput>(response);
            }

        }

        public async Task<GSTNResult<TOutput>> PatchAsync<TInput, TOutput>(TInput data)
        {
            using (var client = GetHttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), url2);
                request.Content = new StringContent(JsonConvert.SerializeObject(data));
                HttpResponseMessage response = await client.SendAsync(request);
                return BuildResponse<TOutput>(response);
            }

        }

        public async Task<GSTNResult<bool>> DeleteAsync()
        {
            using (var client = GetHttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(url2);
                return BuildResponse<bool>(response);
            }

        }

        #endregion

        public GSTNResult<TOutput> Get<TOutput>()
        {


            var _task = Task.Run(() => { return GetAsync<TOutput>(); });

            _task.Wait();
            var result = _task.Result;
            return result;
        }

        public async Task<GSTNResult<TOutput>> Post<TInput, TOutput>(TInput data)
        {
            return await PostAsync<TInput, TOutput>(data);
        }

        public GSTNResult<TOutput> Put<TInput, TOutput>(TInput data)
        {

            var _task = Task.Run(() => { return PutAsync<TInput, TOutput>(data); });

            _task.Wait();
            var result = _task.Result;
            return result;
        }

        public GSTNResult<TOutput> Patch<TInput, TOutput>(TInput data)
        {


            var _task = Task.Run(() => { return PatchAsync<TInput, TOutput>(data); });

            _task.Wait();
            var result = _task.Result;
            return result;
        }

        public GSTNResult<bool> Delete()
        {


            var _task = Task.Run(() => { return DeleteAsync(); });

            _task.Wait();
            var result = _task.Result;
            return result;
        }

        protected HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.Timeout = timeout;
            BuildHeaders(client);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        protected internal abstract void BuildHeaders(HttpClient client);

        protected virtual GSTNResult<TOutput> BuildResponse<TOutput>(HttpResponseMessage response)
        {
            //This function can be used to convert simple API result to ResultInfo based API result
            GSTNResult<TOutput> resultInfo = new GSTNResult<TOutput>();
            resultInfo.HttpStatusCode = Convert.ToInt32(response.StatusCode.ToString("D"));
            var str1 = response.Content.ReadAsStringAsync().Result;
            System.Console.WriteLine("Obtained Result:" + str1 + System.Environment.NewLine);
            if (resultInfo.HttpStatusCode == (int)HttpStatusCode.OK)
            {
                if (typeof(TOutput) == typeof(String))
                {
                    var result = (TOutput)(Object)str1;
                    resultInfo.Data = result;
                }
                else
                {
                    var result = JsonConvert.DeserializeObject<TOutput>(str1);
                    resultInfo.Data = result;
                }
            }
            else
            {
                resultInfo.Message = str1;
            }
            return resultInfo;
        }





        public void Dispose()
        {
        }

    }

}