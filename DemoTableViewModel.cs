using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using Newtonsoft.Json;
using Parse;

namespace Xamarin.iOSTableView
{
	//Create Data Class to ingest museum information
	public class Data
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string Image { get; set; }
	}

	//Set up the model
	public class DemoTableViewModel
	{
		List<Data> _model = new List<Data>();
	
		public Data this[int index]
		{
			get { return _model[index]; }
			set { _model[index] = value; }
		}
		public List<Data> data
		{
			get { return _model; }
			set { _model = value; }
		}
		public int Count
		{
			get { return _model.Count; }
		}

		public void Add(Data item)
		{
			_model.Add(item);
		}

		//Add data into model using JSON or Parse
		//public static async Task<DemoTableViewModel> Init()
		public static DemoTableViewModel Init()
		{
			
			DemoTableViewModel model = new DemoTableViewModel();
			//ParseQuery<ParseObject> query = ParseObject.GetQuery("Museum");

			//IEnumerable<ParseObject> Museum = await query.FindAsync();

			//foreach (var museum in Museum)
			//{

			//	model.Add(new Data
			//	{
			//		Name = museum.Get<string>("Name"),
			//		Address = museum.Get<string>("Address"),
			//		Latitude = museum.Get<double>("Latitude"),
			//		Longitude = museum.Get<double>("Longitude"),
			//		Image = museum.Get<string>("Image")
			//	});
			//}
			var jsonFile = JsonConvert.DeserializeObject<RootObject>(System.IO.File.ReadAllText("Museum.json"));
			foreach (var museum in jsonFile.Museum)
			{
				model.Add(new Data
				{
					Name = museum.Name,
					Address = museum.Address,
					Latitude = museum.Latitude,
					Longitude = museum.Longitude,
					Image = museum.Image
				});
			}


			return model;
		}

	}
}


