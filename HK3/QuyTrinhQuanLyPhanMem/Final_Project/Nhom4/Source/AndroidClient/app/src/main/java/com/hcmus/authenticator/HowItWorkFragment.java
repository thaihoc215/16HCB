package com.hcmus.authenticator;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;


public class HowItWorkFragment extends Fragment {


    int resourceLayout;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Bundle bundle = this.getArguments();

        if (bundle != null) {
            resourceLayout = bundle.getInt("resourceLayout", R.layout.fragment_how_it_work_1);
        } else {
            resourceLayout = R.layout.fragment_how_it_work_1;
        }
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        return inflater.inflate(resourceLayout, container, false);

    }

    public static HowItWorkFragment newInstance(int resourceLayout) {

        HowItWorkFragment f = new HowItWorkFragment();
        Bundle b = new Bundle();
        b.putInt("resourceLayout", resourceLayout);

        f.setArguments(b);

        return f;
    }

}
