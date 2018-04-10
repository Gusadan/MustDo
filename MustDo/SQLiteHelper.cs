using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MustDo
{
    class SQLiteHelper : SQLiteOpenHelper
    {
        private const string qry_create_table = "CREATE TABLE Task (id integer primary key, name text)";
        private static String DATABASE_NAME = "MustDo.db";

        public SQLiteHelper(Context context)
            : base(context, DATABASE_NAME, null, 2)
        {

        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(sql: qry_create_table);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL("DROP TABLE IF EXISTS Task");
            OnCreate(db);
        }

        public bool insertTask(String name)
        {
            SQLiteDatabase db = this.WritableDatabase;
            ContentValues contentValues = new ContentValues();
            contentValues.Put("name", name);

            db.Insert("Task", null, contentValues);
            return true;
        }

        public System.Collections.ArrayList getAllTasks()
        {
            System.Collections.ArrayList array_list = new System.Collections.ArrayList();

            //hp = new HashMap();
            SQLiteDatabase db = this.ReadableDatabase;
            ICursor res = db.RawQuery("SELECT * FROM Task", null);
            res.MoveToFirst();

            while (res.IsAfterLast == false)
            {
                array_list.Add(res.GetString(res.GetColumnIndex("name")));
                res.MoveToNext();
            }
            return array_list;
        }
    }
}