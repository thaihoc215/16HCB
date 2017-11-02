package com.hcmus.authenticator;

import android.app.AlarmManager;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.net.ConnectivityManager;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.ListViewCompat;
import android.support.v7.widget.Toolbar;
import android.text.TextPaint;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.StringTokenizer;

import retrofit.Call;
import retrofit.Callback;
import retrofit.GsonConverterFactory;
import retrofit.Response;
import retrofit.Retrofit;
import retrofit.http.GET;
import retrofit.http.Query;

public class CaiDatActivity extends AppCompatActivity implements Callback<CaiDatActivity.ThoiGianHeThong> {

    ListView lstDanhSachChucNang;
    ArrayList<String> mangChucNang=new ArrayList<String>();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cai_dat);

        // Get a support ActionBar corresponding to this toolbar
        ActionBar ab = getSupportActionBar();
        // Enable the Up button
        ab.setDisplayHomeAsUpEnabled(true);

        getSupportActionBar().setBackgroundDrawable(new ColorDrawable(Color.parseColor( "#4285F4")));

        mangChucNang.add("Đồng bộ thời gian");
        mangChucNang.add("Giới thiệu về tính năng này");
        lstDanhSachChucNang=(ListView)findViewById(R.id.lstChucNang);
        ArrayAdapter<String> adapter=new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1, android.R.id.text1,mangChucNang);
        lstDanhSachChucNang.setAdapter(adapter);

        lstDanhSachChucNang.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if(position==0){
                    ConnectivityManager connectivityManager=(ConnectivityManager)getSystemService(CONNECTIVITY_SERVICE);
                    if(!connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).isConnected() && !connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).isConnected()){
                        Toast.makeText(getBaseContext(),"Tính năng này cần phải có kết nối Internet.",Toast.LENGTH_LONG).show();
                        return;
                    }
                    Retrofit retrofit = new Retrofit.Builder()
                            .baseUrl("http://2stepauthentication.azurewebsites.net")
                            // Sử dụng GSON cho việc parse và maps JSON data tới Object
                            .addConverterFactory(GsonConverterFactory.create())
                            .build();

                    // Khởi tạo các cuộc gọi cho Retrofit 2.0
                    LayThoiGianAPI API = retrofit.create(LayThoiGianAPI.class);

                    Call<ThoiGianHeThong> call = API.layThoiGian();
                    // Cuộc gọi bất đồng bọ (chạy dưới background)
                    call.enqueue(CaiDatActivity.this);

                }
                else{
                    Intent intent =new Intent(CaiDatActivity.this,HienThiTroGiupActivity.class);
                    intent.putExtra("link","https://support.google.com/accounts/answer/2653433?visit_id=0-636193679506650019-3997375985&p=timesync&rd=1");
                    startActivity(intent);
                }

            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        onBackPressed();
        return true;
    }

    @Override
    public void onResponse(Response<ThoiGianHeThong> response, Retrofit retrofit) {
        Long thoiGianHienTai=Long.parseLong(response.body().longTime);
        Long thoiGianChenhLech=thoiGianHienTai-System.currentTimeMillis();

        SharedPreferences pre=getSharedPreferences("DongBoThoiGian",MODE_PRIVATE);
        SharedPreferences.Editor edit=pre.edit();
        edit.putLong("ThoiGianChenhLech",thoiGianChenhLech);
        edit.commit();
        Toast.makeText(getApplication().getBaseContext(),"Đồng bộ thời gian thành công", Toast.LENGTH_LONG).show();
    }

    @Override
    public void onFailure(Throwable t) {
        Log.d("erro", t.toString());
    }
    public interface LayThoiGianAPI{
        @GET("/api/android/synctime")
        Call<ThoiGianHeThong> layThoiGian();
    }
    public class ThoiGianHeThong{
        String longTime;
        String type;
    }
}
