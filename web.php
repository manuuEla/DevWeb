<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/


Route::get("/",function(){
   return view("front-end.index");
});
Route::get("/dashboard/admin","AdminsController@indexAdm");
Route::get("/dashboard/post","PostsController@indexPost");
Route::get("/dashboard/category", "CategoriesController@indexCat");

Route::post("/dashboard/post/save/{id}","PostsController@save");
Route::post("/dashboard/post/add","PostsController@add");
Route::get("/dashboard/post/delete/{id}", "PostsController@delete");

Route::post("/dashboard/category/save/{id}","CategoriesController@save");
Route::post("/dashboard/category/add","CategoriesController@add");
Route::get("/dashboard/category/delete/{id}","CategoriesController@delete");

Route::post("/dashboard/admin/save/{id}", "AdminsController@save");
Route::post("/dashboard/admin/add","AdminsController@add");
Route::get("/dashboard/admin/delete/{id}","AdminsController@delete");