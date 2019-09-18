<?php

namespace App\Http\Controllers;

use App\Post;
use Illuminate\Http\Request;

class PostsController extends Controller
{
    function indexPost()
    {
        $posts = \App\Post::all();
        return view("post.index", array("posts" => $posts));
    }
    function save($id, Request $request){
        $post=Post::find($id);
        $post->title=$request->title;
        $post->url_seo=$request->url_seo;
        $post->continut=$request->continut;
        if($request->hasFile("poza")){
            $post->img=self::uploadFile($request,"poza","posts-images",array("jpg","jpeg","png","gif","ico","svg"),false);

        }
        $post->save();
        return back();

    }
     function add(Request $request){
      $post = new Post;
      $post->title=$request->title;
      $post->url_seo=$request->url_seo;
      $post->continut=$request->continut;
      $post->category_id=$request->category_id;
      $post->img=self::uploadFile($request,"poza","posts-images",array("jpg","jpeg","png","gif","ico","svg"),false);
      $post->save();
      return back();
     }
     function delete($id){
         $post=Post::find($id);
         $post->delete();
         return back();
     }

    public static function uploadFile($request, $field_name, $directory, $allowed_extensions = array(),$multiple=false)
    {
        if($multiple==false) {
            $file = $request->file($field_name);

            $ok = 0;
            if (count($allowed_extensions) > 0) {
                foreach ($allowed_extensions as $allowed_extension) {
                    if ($allowed_extension == strtolower($file->getClientOriginalExtension())) {
                        $ok = 1;
                        break;
                    }
                }
            } else {
                $ok = 1;
            }
            if ($ok == 0) {
                return false;
            }
            $name = rand(0, 99999) . time() . "." . strtolower($file->getClientOriginalExtension());
            $destinationPath = base_path() . '/storage/app/public/' . $directory . "/";
            $file->move($destinationPath, $name);
            return $name;
        }else{
            //dd($field_name);
            $uploaded_files=array();

            $files=$request->file($field_name);
            foreach($files as $file) {

                $ok = 0;
                if (count($allowed_extensions) > 0) {
                    foreach ($allowed_extensions as $allowed_extension) {
                        if ($allowed_extension == strtolower($file->getClientOriginalExtension())) {
                            $ok = 1;
                            break;
                        }
                    }
                } else {
                    $ok = 1;
                }
                if ($ok == 0) {
                    array_push($uploaded_files,false);
                }
                $name = rand(0, 99999) . time() . "." . strtolower($file->getClientOriginalExtension());
                $destinationPath = base_path() . '/storage/app/public/' . $directory . "/";
                $file->move($destinationPath, $name);
                array_push($uploaded_files,$name);
            }
            return $uploaded_files;
        }
    }
}
