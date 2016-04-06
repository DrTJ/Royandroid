package {PackageName};

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import ir.royapajoohesh.DataLib.TableBase;

/* Created by Dr TJ @ March 2015 */

public class {TableName}OpenHelper extends SQLiteOpenHelper {
	public static String TAG = "{TableName}OpenHelper";

    public TableBase {TableName}Table = null;

    public static final String DatabaseName = "{DatabaseName}.db";
    public static final String TableName = "{TableName}";
    public static final int Version = 1;

    public {TableName}OpenHelper(Context context) {
        super(context, DatabaseName, null, Version);

        this.{TableName}Table = new TableBase(DatabaseName, TableName);
        {AddColumns()}
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String res = this.{TableName}Table.getCreateTableCommandText();
        db.execSQL(res);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        String res = this.{TableName}Table.getDropTableCommandText();
        db.execSQL(res);
        this.onCreate(db);
    }
}
