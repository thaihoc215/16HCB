package com.example.min.graviy_bt02_tuan03;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.Toast;
import android.widget.RadioGroup;
import android.widget.RadioButton;
import java.text.ParseException;
import java.text.SimpleDateFormat;

public class registerform extends AppCompatActivity {

    private Button btnSignup, btnReset;
    private EditText txtUsername, txtPassword, txtRetype, txtBirthday;
    private RadioGroup radioGroup;
    private RadioButton radioButton;
    private CheckBox cbTenis, cbFootball, cbOthers;
    private String Hobbies = "";
    public static final String USERNAME = "com.example.sonlpq.MESSAGE";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.registerform);
        btnSignup = (Button)findViewById(R.id.btnSignup);
        btnReset = (Button)findViewById(R.id.btnReset);
        txtUsername = (EditText)findViewById((R.id.txtUsername));
        txtPassword = (EditText)findViewById(R.id.txtPassword);
        txtRetype = (EditText)findViewById(R.id.txtRetype);
        txtBirthday = (EditText)findViewById(R.id.txtBirthday);
        radioGroup = (RadioGroup)findViewById(R.id.radio);
        cbTenis = (CheckBox)findViewById(R.id.cbTenis);
        cbFootball = (CheckBox)findViewById(R.id.cbFootball);
        cbOthers = (CheckBox)findViewById(R.id.cbOthers);
        btnSignup.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                sendMessages(view);
            }
        });
        btnReset.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                resetFrom(view);
            }
        });
    }

    public void resetFrom(View view){
        txtPassword.setText("");
        txtRetype.setText("");
        txtUsername.setText("");
        txtBirthday.setText("");
        cbOthers.setChecked(false);
        cbFootball.setChecked(false);
        cbTenis.setChecked(false);

    }

    public void sendMessages(View view){
        Intent intent = new Intent(registerform.this, resultform.class);
        int selectedId = radioGroup.getCheckedRadioButtonId();
        //lay gioi tinh
        radioButton = (RadioButton) findViewById(selectedId);
        //lay so thich
        Boolean flag = false;
        if(cbTenis.isChecked()){
            Hobbies = "Tenis";
            flag = true;
        }
        if(cbFootball.isChecked()){
            if(flag){
                Hobbies += ", Football";
            }else{
                Hobbies = "Football";
                flag = true;
            }
        }
        if(cbOthers.isChecked()){
            if(flag){
                Hobbies += ", Others";
            }else{
                Hobbies = "Others";
            }
        }

        if(txtPassword.getText().toString().matches(txtRetype.getText().toString())){

        }else{
            Toast.makeText(this, "Password incorrect", Toast.LENGTH_SHORT).show();
            return;
        }
        if(txtUsername.getText().toString().matches("")){
            Toast.makeText(this, "You did not enter a username", Toast.LENGTH_SHORT).show();
            return;

        }else if(txtPassword.getText().toString().matches("")){
            Toast.makeText(this, "You did not enter a password", Toast.LENGTH_SHORT).show();
            return;
        }
        else if(txtBirthday.getText().toString().matches("")){
            Toast.makeText(this, "You did not enter a birth day", Toast.LENGTH_SHORT).show();
            return;
        }
        else{
            SimpleDateFormat dateFormat = new SimpleDateFormat("dd/mm/yyyy");
            dateFormat.setLenient(false);
            try {
                dateFormat.parse(txtBirthday.getText().toString().trim());
            } catch (ParseException pe) {
                Toast.makeText(this, "Invalid format date", Toast.LENGTH_SHORT).show();
                return;
            }
            intent.putExtra("username", txtUsername.getText().toString());
            intent.putExtra("password", txtPassword.getText().toString());
            intent.putExtra("hobbies", Hobbies);
            intent.putExtra("birthday", txtBirthday.getText().toString());
            intent.putExtra("gender", radioButton.getText().toString());
            startActivity(intent);
        }

    }
}
