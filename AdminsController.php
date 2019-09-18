<?php

namespace App\Http\Controllers;

use App\Admin;
use Illuminate\Http\Request;

class AdminsController extends Controller
{
    function indexAdm()
    {
       $admins = \App\Admin::all();
        return view("admin.index", array("admins" => $admins));
    }

    function save($id, Request $request){
        $admin=Admin::find($id);
        $admin->email=$request->email;
        if(trim($request->password)!="") {
            $admin->password = password_hash($request->password, PASSWORD_BCRYPT);
        }
        $admin->name=$request->name;
        $admin->save();
        return back();

    }
    function add(Request $request){
        $admin =new Admin;
        $admin->email=$request->email;
        $admin->password=password_hash($request->password,PASSWORD_BCRYPT);
        $admin->name=$request->name;
        $admin->save();
        return back();
    }
    function delete($id){
        $admin=Admin::find($id);
        $admin->delete();
        return back();
    }

}