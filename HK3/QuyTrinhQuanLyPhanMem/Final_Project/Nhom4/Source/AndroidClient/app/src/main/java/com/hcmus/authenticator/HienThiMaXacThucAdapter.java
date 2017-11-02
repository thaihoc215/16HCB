package com.hcmus.authenticator;

import android.app.Activity;
import android.content.Context;
import android.os.CountDownTimer;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import com.mikhaellopez.circularprogressbar.CircularProgressBar;

import java.util.ArrayList;
import java.util.Random;

/**
 * Created by MyPC on 15/12/2016.
 */

public class HienThiMaXacThucAdapter extends BaseAdapter{
    Context context=null;
    ArrayList<TaiKhoan> dsTaiKhoan=null;
    public view_mot_o motO;
    public HienThiMaXacThucAdapter(Context c, ArrayList<TaiKhoan> dsTaiKhoanXacThuc){
        this.context=c;
        this.dsTaiKhoan=dsTaiKhoanXacThuc;
    }
    @Override
    public int getCount() {
        return dsTaiKhoan.size();
    }

    @Override
    public Object getItem(int position) {
        return dsTaiKhoan.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater flater=((Activity)context).getLayoutInflater();
        if(convertView==null){
            convertView=flater.inflate(R.layout.custom_layout_hien_thi_mot_ma_xac_thuc,null);
            motO=new view_mot_o();
            motO.tvTenTaiKhoan=(TextView)convertView.findViewById(R.id.tvTenTaiKhoan);
            motO.tvMaXacThuc=(TextView)convertView.findViewById(R.id.tvMaXacThuc);
            motO.tvEmail=(TextView)convertView.findViewById(R.id.tvEmail);
        }
        else
            motO=(view_mot_o)convertView.getTag();
        motO.tvTenTaiKhoan.setText(dsTaiKhoan.get(position).getTenTaiKhoan());
        motO.tvMaXacThuc.setText(dsTaiKhoan.get(position).getMaXacThuc());
        motO.tvEmail.setText(dsTaiKhoan.get(position).getEmail());
        return convertView;
    }

    public static class view_mot_o{
        TextView tvMaXacThuc;
        TextView tvTenTaiKhoan;
        TextView tvEmail;
    }
}
