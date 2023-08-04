using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
 
public class SwapMaterials : EditorWindow
{
    // エディタウィンドウを開く
    [MenuItem("Window/Test/SwapMaterials")]
    public static void CreateWindow()
    {
        EditorWindow.GetWindow<SwapMaterials>();
    }
 
    // 置き換えるマテリアル
    Material material_to;
    Material material_from;
 
    // マテリアルを置き換えたゲームオブジェクトのリスト
    List<GameObject> swappedObjs = new List<GameObject>();
 
    private void OnGUI()
    {
        // 置き換え元のマテリアルを取得
        material_from = (Material)EditorGUILayout.ObjectField("From" , material_from, typeof(Material), false);
        
        // 置き換え先のマテリアルを取得
        material_to = (Material)EditorGUILayout.ObjectField("To" , material_to, typeof(Material), false);
 
        // マテリアルが取得されたら
        if (material_from != null && material_to != null)
        {
            // 置換ボタンを押すと
            if (GUILayout.Button("置換"))
            {
                // リストをクリア
                swappedObjs.Clear();
 
                // すべてのゲームオブジェクト
                foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
                {
                    // ヒエラルキーにあるゲームオブジェクト
                    if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                    {
 
                        // レンダラーコンポーネントを取得
                        var r = go.GetComponent<Renderer>();
                        
                        // レンダラーコンポーネントがなければ次のゲームオブジェクトを処理
                        if (r == null) continue;
 
                        // マテリアルを置き換えたかどうかのフラグ
                        bool flag = false;
 
                        // レンダラーに設定されているマテリアル配列をコピー
                        var materials = r.sharedMaterials;
                        
                        // マテリアルを一つずつ見る
                        for(int i = 0; i < materials.Length; i++)
                        {
                            // 置き換え元のマテリアルと同じものがあれば
                            if (r.sharedMaterials[i] == material_from)
                            {
                                // 置き換え先のマテリアルと置き換え
                                materials[i] = material_to;
                                
                                // フラグをtrueにする
                                flag = true;
                            }
                        }
 
                        // 置き換えなければ次を処理
                        if (!flag) continue;
 
                        // 置き換えたマテリアル配列をレンダラーに設定。
                        r.sharedMaterials = materials;
 
                        // 置き換えたゲームオブジェクトのリストに追加
                        swappedObjs.Insert(0, go);
 
                        // 保存対象にする
                        EditorUtility.SetDirty(go);
                    }
                }
            }
            // クリアボタンを押す
            else if(GUILayout.Button("クリア"))
            {
                // リストをクリア
                swappedObjs.Clear();
            }
 
            // 置換されたゲームオブジェクトがあるとき
            if(swappedObjs != null || swappedObjs.Count > 0)
            {
                // 一つずつ処理
                foreach (var o in swappedObjs)
                {
                    // ゲームオブジェクトが削除されていれば
                    if (o == null)
                    {
                        // リストから削除
                        swappedObjs.Remove(o);
 
                        // 処理を終了
                        break;
                    }
 
                    // ボタンを表示する。ボタン上にゲームオブジェクトの名前を表示。
                    if (GUILayout.Button(o.name, EditorStyles.textField))
                    {
                        // ボタンをクリックすると、そのゲームオブジェクトを選択する。
                        Selection.activeGameObject = o;
                    }
                }
            }
        }
    }
}