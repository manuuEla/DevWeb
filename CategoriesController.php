<?php

namespace App\Http\Controllers;

use App\Category;
use Illuminate\Http\Request;

class CategoriesController extends Controller
{
    function indexCat()
    {

        $categories = \App\Category::all();
        return view("category.index", array("categories" => $categories));
    }

    function save($id, Request $request){
        $category=Category::find($id);
        $category->nume=$request->nume;
        $category->save();
        return back();

    }
    function add(Request $request){
        $category = new Category;
        $category->nume=$request->nume;
        $category->parent_id=1;
        $category->save();
        return back();
    }
    function delete($id){
        $category=Category::find($id);
        $category->delete();
        return back();
    }
}
