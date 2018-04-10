using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Views;
using Android.Content;
using System;

namespace MustDo
{
    [Activity(Label = "MustDo", MainLauncher = true, Theme ="@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        ListView listViewTasks;
        SQLiteHelper sqliteHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            listViewTasks = FindViewById<ListView>(Resource.Id.listViewTasks);
            sqliteHelper = new SQLiteHelper(this);
            


            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Must Do";
        }

        protected override void OnStart()
        {
            base.OnStart();
            System.Collections.ArrayList dataList = sqliteHelper.getAllTasks();
            String[] myArr = (String[])dataList.ToArray(typeof(string));
            listViewTasks.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleExpandableListItem1, myArr);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.my_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "wew " + item.TitleFormatted, ToastLength.Short).Show();
            var addItemIntent = new Intent(this, typeof(AddItemActivity));
            base.StartActivity(addItemIntent);
            return base.OnOptionsItemSelected(item);
        }
    }
}

