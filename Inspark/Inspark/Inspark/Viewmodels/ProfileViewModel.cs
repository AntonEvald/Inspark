using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Inspark.Models;
using Inspark.Views;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
	class ProfileViewModel : BaseViewModel
	{

		public ProfileViewModel(User e)
		{
			FirstName = e.FirstName;
			LastName = e.LastName;
			Email = e.Email;
			PhoneNumber = e.PhoneNumber;
			ProfilePicture = e.ProfilePicture;
			Section = e.Section;
		}

		public ProfileViewModel()
		{
			GetUser();
		}

		private async void GetUser()
		{
			var e = await _api.GetLoggedInUser();
			FirstName = e.FirstName;
            LastName = e.LastName;
            Email = e.Email;
            PhoneNumber = e.PhoneNumber;
            ProfilePicture = e.ProfilePicture;
            Section = e.Section;
		}

		private string _section;

		public string Section
		{
			get { return _section; }
			set
			{
				_section = value;
				OnPropertyChanged();
			}
		}

		private string _phoneNumber;

		public string PhoneNumber
		{
			get { return _phoneNumber; }
			set
			{
				_phoneNumber = value;
				OnPropertyChanged();
			}
		}

		private byte[] _profilePicture;

		public byte[] ProfilePicture
		{
			get { return _profilePicture; }
			set
			{
				_profilePicture = value;
				OnPropertyChanged();
			}
		}

		private string _email;

		public string Email
		{
			get { return _email; }
			set
			{
				_email = value;
				OnPropertyChanged();
			}
		}

		private string _lastName;

		public string LastName
		{
			get { return _lastName; }
			set
			{
				_lastName = value;
				OnPropertyChanged();
			}
		}

		private string _firstName;

		public string FirstName
		{
			get { return _firstName; }
			set
			{
				_firstName = value;
				OnPropertyChanged();
			}
		}

		private int _id;

		public int Id
		{
			get { return _id; }
			set
			{
				_id = value;
				OnPropertyChanged();
			}
		}
	}
}
