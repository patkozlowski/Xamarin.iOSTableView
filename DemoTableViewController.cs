using System;
using ExternalMaps.Plugin;
using Foundation;
using SDWebImage;
using UIKit;

namespace Xamarin.iOSTableView
{
	public partial class DemoTableViewController : UITableViewController
	{
		protected DemoTableViewController(IntPtr handle) : base(handle)
		{
		}

		public /*async*/ override void ViewWillAppear(bool animated)
		{

			base.ViewWillAppear(animated);
			TableView.ReloadData();
			NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;

			//Load the TableSource use await for async call to Parse Server
			this.TableView.Source = new TableSource(/*await*/ DemoTableViewModel.Init());
			TableView.ReloadData();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}

	}
	public class TableSource : UITableViewSource
	{
		private DemoTableViewModel _model = new DemoTableViewModel();
		private string _cellIdentifier = "Cell";

		public TableSource(DemoTableViewModel source)
		{
			//Set tablesource constructor to get model
			_model = source;
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(_cellIdentifier);

			if (cell == null)
			{
				//Set image
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, _cellIdentifier);
				cell.ImageView.SetImage(new NSUrl(_model[indexPath.Row].Image),
				placeholder: UIImage.FromBundle("image.jpg"));
			}
			//Set Name & Address
			cell.TextLabel.Text = _model[indexPath.Row].Name;
			cell.DetailTextLabel.Text = _model[indexPath.Row].Address;

			return cell;
		}
		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return _model.Count;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//Row clicked, navigate to clicked location
			var Name = _model[indexPath.Row].Name;
			var Latitude = _model[indexPath.Row].Latitude;
			var Longitude = _model[indexPath.Row].Longitude;

			CrossExternalMaps.Current.NavigateTo(Name, Latitude, Longitude, ExternalMaps.Plugin.Abstractions.NavigationType.Driving);
				
			tableView.DeselectRow(indexPath, true);
		}

	}
}
