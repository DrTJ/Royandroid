package {PackageName};

import android.database.sqlite.SQLiteDatabase;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import java.util.ArrayList;
import ir.royapajoohesh.DataLib.TableBase;

/* Created by Dr TJ @ March 2015  */

public class {TableName}DataSource {
	public static String TAG = "{TableName}DataSource";

    SQLiteDatabase database;
    {TableName}OpenHelper dbHelper;

    public static String[] AllColumns = {
        {ColumnNames()}
    };

    public {TableName}DataSource(Context context){
        this.dbHelper = new {TableName}OpenHelper(context);
    }

    public void Open(){
        this.database = dbHelper.getWritableDatabase();

		if (TableBase.isTableExists(this.database, {TableName}OpenHelper.TableName) == false){
			this.dbHelper.onCreate(this.database);
		}
    }

    public void Close(){
        dbHelper.close();
    }

    public {TableName} Insert({TableName} new{TableName}Values, Boolean overwriteExisting){
        if(this.IsDuplicate({PKsAsParameterValuesFromObjectVariable})) {
        	if(overwriteExisting)
        		return Update(new{TableName}Values);
        	else
        		return GetItem({PKsAsParameterValuesFromObjectVariable});
        }
    	
		ContentValues values = new ContentValues();

        {InsertParameterValues()}

        this.database.insert({TableName}OpenHelper.TableName, null, values);
        return new{TableName}Values;
    }

    public {TableName} Update({TableName} new{TableName}Values){
        ContentValues values = new ContentValues();

		{UpdateParameterValues()}

        String whereArgs[] = new String[{WhereClausesCount}];
        {WhereArgsList()}

        this.database.update({TableName}OpenHelper.TableName, values, "{WhereClauseString}", whereArgs);
        return new{TableName}Values;
    }

    public int Delete({DeleteParams()}){
        String whereArgs[] = new String[{WhereClausesCount}];
        {DeleteWhereArgsList()}

        return this.database.delete({TableName}OpenHelper.TableName, "{WhereClauseString}", whereArgs);
    }

	public Cursor SelectAllAsCursor() {
        Cursor cursor = this.database.query({TableName}OpenHelper.TableName, {TableName}DataSource.AllColumns, null, null, null, null, null);
        return cursor;
    }

    public ArrayList<{TableName}> SelectAll(){
        ArrayList<{TableName}> res = new ArrayList<{TableName}>();
        Cursor cursor = this.database.query({TableName}OpenHelper.TableName, {TableName}DataSource.AllColumns, null, null, null, null, null);
        if(cursor.getCount() > 0){
            while (cursor.moveToNext()) {
				{TableName} item = {TableName}.FromCursor(cursor);
            	
				res.add(item);
            }
        }

		cursor.close();
        return res;
    }


    public ArrayList<{TableName}> Select(String whereClause, String orderByClause){
        ArrayList<{TableName}> res = new ArrayList<{TableName}>();
        Cursor cursor = this.database.query({TableName}OpenHelper.TableName, {TableName}DataSource.AllColumns, whereClause, null, null, null, orderByClause);

        if(cursor.getCount() > 0){
            while (cursor.moveToNext()) {
				{TableName} item = {TableName}.FromCursor(cursor);
            	res.add(item);
			}
        }

		cursor.close();
        return res;
    }

    public void ReplaceRows(ArrayList<{TableName}> res) {
        if (TableBase.isTableExists(this.database, {TableName}OpenHelper.TableName) == false){
			this.dbHelper.onCreate(this.database);
		}
		
		// clear all rows
		this.database.delete({TableName}OpenHelper.TableName, null, null);

		// add new one
        for ({TableName} item : res) {
            Insert(item, true);
        }
    }

	public Boolean IsDuplicate({DeleteParams()}) {
        String whereArgs[] = new String[{WhereClausesCount}];
        {DeleteWhereArgsList()}

		if(TableBase.isTableExists(this.database, {TableName}OpenHelper.TableName) == false)
			return false;

        Cursor cursor = this.database.query({TableName}OpenHelper.TableName, {TableName}DataSource.AllColumns, "{WhereClauseString}", whereArgs, null, null, null);
        int count = cursor.getCount();
		cursor.close();

		return count > 0;	
	}

	public {TableName} GetItem({DeleteParams()}){
        String whereArgs[] = new String[{WhereClausesCount}];
        {DeleteWhereArgsList()}

        Cursor cursor = this.database.query({TableName}OpenHelper.TableName, {TableName}DataSource.AllColumns, "{WhereClauseString}", whereArgs, null, null, null);
		
		{TableName} res;
		if (cursor.moveToNext()) {
			res = {TableName}.FromCursor(cursor);
		} else
			res = null;

		cursor.close();
		return res;
	}

	public static void Insert(Context context, {TableName} newItem) {
		{TableName}DataSource ds{TableName} = new {TableName}DataSource(context);
		ds{TableName}.Open();
		ds{TableName}.Insert(newItem, true);
		ds{TableName}.Close();
	}

	public static void DeleteAll(Context context) {
		{TableName}DataSource ds{TableName} = new {TableName}DataSource(context);
		
		ds{TableName}.Open();
		ds{TableName}.database.delete({TableName}OpenHelper.TableName, null, null);
		ds{TableName}.Close();
	}

	public static int GetCount(Context context) {
		{TableName}DataSource ds{TableName} = new {TableName}DataSource(context);
		
		ds{TableName}.Open();
		int res = ds{TableName}.SelectAll().size();
		ds{TableName}.Close();

		return res;
	}
}