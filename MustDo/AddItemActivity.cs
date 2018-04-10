using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MustDo
{
    [Activity(Label = "AddItemActivity")]
    public class AddItemActivity : Activity
    {
        private SQLiteHelper sqliteHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_add_item);

            var buttonAdd = FindViewById<Button>(Resource.Id.buttonAddTask);
            var editTextTaskName = FindViewById<EditText>(Resource.Id.editTextTaskName);
            sqliteHelper = new SQLiteHelper(this);

            buttonAdd.Click += delegate {
                if (editTextTaskName.Text.ToString().Equals((String.Empty).Trim()))
                {
                    Toast.MakeText(this, "Fields Empty Found", ToastLength.Short).Show();
                }
                else
                {
                    sqliteHelper.insertTask(editTextTaskName.Text.ToString());
                    Toast.MakeText(this, "Data Successfully Stored", ToastLength.Short).Show();
                }
            };
        }
    }
}