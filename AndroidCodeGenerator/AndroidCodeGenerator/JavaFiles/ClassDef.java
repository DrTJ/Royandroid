package {PackageName};

import android.database.Cursor;
import android.os.Parcel;
import android.os.Parcelable;
import org.json.JSONException;
import org.json.JSONObject;
import java.sql.Blob;

/* Created by Dr TJ @ March 2015 */

public class {TableName} implements Parcelable {
	public static String TAG = "{TableName}";

    {PropertyDeclaration()}

	{columnNamesAsStringList()}

    public {TableName}() { }

	public {TableName}({ConstructorParameters}) { 
		{ConstructorAssignments()}
	}

    public {TableName}(Parcel in) {
        {ParcelAssignments()}
    }

    @Override
    public int describeContents() { return 0; }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        {WriteToParcel()}
    }

    @Override
    public String toString() {
        return {ToString()};
    }

    public static final Parcelable.Creator<{TableName}> CREATOR = new Creator<{TableName}>() {
        @Override
        public {TableName}[] newArray(int size) {
            return new {TableName}[size];
        }

        @Override
        public {TableName} createFromParcel(Parcel source) {
            return new {TableName}(source);
        }
    };


    // static methods
    public static {TableName} FromJSon(JSONObject jsonItem) throws JSONException {
        {TableName} res = new {TableName}();

        {FromJSonAssignment()}

        return res;
    }

    public static {TableName} FromCursor(Cursor cursorItem) {
        {TableName} res = new {TableName}();

        {FromCursorAssignment()}

        return res;
    }

}
