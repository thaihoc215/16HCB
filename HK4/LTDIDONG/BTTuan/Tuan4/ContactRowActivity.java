package gravity.hcb16.baitap_tuan3;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

/**
 * Created by HOCHNT on 3/18/2018.
 */

public class ContactRowActivity extends ArrayAdapter<String> {

    Context context;
    Integer[] thumbnails;
    String[] items;
    String[] itemsPhone;

    public ContactRowActivity(Context context, int layoutToBeInflated, String[] items, String[] itemsPhone, Integer[] thumbnails) {
        super(context, R.layout.contact_row_layout, items);
        this.context = context;
        this.thumbnails = thumbnails;
        this.items = items;
        this.itemsPhone = itemsPhone;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = ((Activity) context).getLayoutInflater();
        View row = inflater.inflate(R.layout.contact_row_layout, null);
        TextView labelName = (TextView) row.findViewById(R.id.labelName);
        TextView labelPhone = (TextView) row.findViewById(R.id.labelPhone);
        ImageView icon = (ImageView) row.findViewById(R.id.icon);
        labelName.setText(items[position]);
        labelPhone.setText(itemsPhone[position]);
        icon.setImageResource(thumbnails[position]);
        return (row);
    }
}
