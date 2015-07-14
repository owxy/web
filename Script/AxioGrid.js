///////////////////////////////////////////////////////////////////////////////////
// Author   : Arain QQ:262739588
// BLOG URL : http://www.blog-design.cn
// Name     : Axio Jquery+ashx Grid插件 (ie6.0/ie7.0 火狐测试通过)
// Function : 结合asp.net ashx实现无刷新显示数据, 无刷新分页, 无刷新搜索, 无刷新排序, 
//            自定义成员按纽
// Date     : 2010/04/02 15:13
///////////////////////////////////////////////////////////////////////////////////
(function($){
	
	$.fn.AxioGrid=function(p)
	{
		return this.each(function(){
			$.BindGird(p,$(this));
        });
	}
	
	$.BindGird=function(p,showbox){
		p = $.extend({
			url:false,  //ajax调用的ashx地址
			data:false, //需要传的参数
			method:"POST", 
			page:1, //当前页码
			rp:5, //每页显示的数据条数
			total:0, //总数据条数
			pages:1, //总页数
			pagestat:'Displaying {from} to {to} of {total} items', //数据页码信息
			sortname:"", //排序字段名称
			sortorder:"", //排序方式
			itembuttons:false, //成员按扭的json数据
			nodataMessage: 'No data in the database.', //接受不到数据时显示的信息
			errorMsg:'<font color="red">Get data faild,please contact administrator.</font>',//AJAX调用错误时的信息
			loginpage:"login.aspx",
			filterable:false,
			filter:false
		},p);	
		
		if(!p.url) return false;
		
		//页面参数传递
		var param="page="+p.page+"&rp="+p.rp+"&sortname="+p.sortname+"&sortorder="+p.sortorder;
		
		//过滤参数传递
		if(p.filterable&&p.filter)
		{
			$.each(p.filter,function(i,filterValue){
				if(filterValue.name!="")
					param+="&"+filterValue.name+"="+filterValue.value;
			});
		}
		
		//搜索参数传递
		if(p.data!="")
		{
			param +="&"+p.data;
		}		
		
		$.ajax({
		   type: p.method,
		   url: p.url,
		   data:param,
		   success: function(msg){
			 $.AddData(msg,showbox,p);
		   },
		   error: function(msg){$.ErrorAjax(showbox,p.errorMsg);},
		   beforeSend:function(){$.AddLoading(showbox);},
		   complete:function(){$.MoveLoading(showbox);}
		});
		 
	};
	
	$.ErrorAjax=function(showbox,errorMsg){
		$(showbox).html(errorMsg);
	}
	
	//加载滚动条
	$.AddLoading=function(showbox){
		$(showbox).hide();
		$(showbox).parent("div").prepend("<div id=\"loading\"></div>");
	}
	
	//删除滚动条
	$.MoveLoading=function(showbox){
		$(showbox).show();
		$(showbox).parent("div").children("#loading").remove()
	}
	
	//填充数据表
	$.AddData=function(data,showbox,p){
		
		$(showbox).addClass("JqueryGrid");
		$(showbox).children("table").remove();
		$(showbox).children("div").remove();
		if(data!="-1") //如果data为-1,表示用户未登陆，跳到指定登陆页面
		{
		    var table=document.createElement("table");
		    //table.className="JqueryGrid";
		    $(table).attr({cellPadding:"0",cellSpacing:"0",border:"0", width:"100%"});
			//alert(data);
		    var json=eval('('+data+')');  //将字符串转化成JSON数据
			
		    if(json.cols.length>0)
		    {
		        var thead=document.createElement("thead");
			    var tr1=document.createElement("tr"); //th行
			    var tr2=document.createElement("tr"); //过滤行
			    //更新当前页码和总页数
			    //alert(json.page);
			    p.total=json.total;
			    p.page=json.page;
			    p.pages=json.pages;
				
			    $.each(json.cols,function(i,col){
				    var th=document.createElement("th");
				    th.innerHTML="<div class=\""+col.className+"\">"+col.display+"</div>"
				    $(th).attr("abbr",col.name);
				    $(th).attr("colid","col"+i);
					
				    //抬头增加排序事件
				    if(col.sortable)
				    {
					    $(th).click(function(){
						    if(p.sortname!=col.name)
						    {
							    p.sortname=col.name;
							    p.sortorder="asc";
						    }
						    else
						    {
							    if(p.sortorder=="asc") 
							    {
								    p.sortorder="desc";
							    }
							    else
							    {
								    p.sortorder="asc";
							    }
    					
						    }
						    $.BindGird(p,showbox);
					    });
				    }
				    //设置排序TH的样式
				    if($(th).attr("abbr")==p.sortname)
				    {
					    $(th).addClass("sort"+p.sortorder);
				    }
					
				    $(tr1).append(th);
					
					//设置过滤列表
					if(p.filterable)
					{
						var td2=document.createElement("td");
						
						var opt="<option></option>";
						if(json[p.filter[i].name]&&json[p.filter[i].name].length>0)
						{
							$.each(json[p.filter[i].name],function(k,filterValue){
								if(filterValue.name!="")
								{
									if(p.filter[i].value==filterValue.name)
										opt += "<option selected=\"selected\">"+filterValue.name+"</option>";
									else
										opt += "<option>"+filterValue.name+"</option>";
								}
							});
							td2.innerHTML="<div class=\""+col.className+"\"><select style=\"width:100%;\" id=\"select"+p.filter[i].name+"\">"+opt+"</select></div>";
						}
						else
						{
							td2.innerHTML="&nbsp;";
						}
						//设置过滤事件
						$(td2).children("div").children("select").change(function(){
						    $.each(p.filter,function(i,filterValue){
								filterValue.value=$("#select"+filterValue.name).val();
							});
							$.BindGird(p,showbox);
						});
						tr2.className="filterTr";
						$(tr2).append(td2);
					}
			    });
    			
			    if(p.itembuttons!=false)
			    {
				    $.each(p.itembuttons,function(i,items){
					    var th=document.createElement("th");
					    th.innerHTML="<div class=\""+items.bthclass+"\">"+items.bthname+"</div>";
					    $(tr1).append(th);
					
						//设置过滤列
						if(p.filterable)
						{
							var td=document.createElement("td");
							td.innerHTML="&nbsp;";
							$(tr2).append(td);
						}
						
				    });
			    }
			    $(thead).append(tr1);
		        $(table).prepend(thead);
		    }
    		
		    var tbody=document.createElement("tbody");
			if(p.filterable)
			{
			    $(tbody).append(tr2);
			}
		    if(json.rows.length>0)
		    {
			    $.each(json.rows,function(i,row){
				    var tr=document.createElement("tr");
				    if(i%2)tr.className='erow';
    				
				    if(row.id) tr.id="row"+row.id;
				    for(var i=0;i<json.cols.length;i++)
				    {
					    var td=document.createElement("td");
					    td.innerHTML="<div class=\""+json.cols[i].className+"\">"+row.cell[i]+"</div>";
					    $(tr).append(td);
					    td=null;
				    }
				    //增加自定义按钮 
				    if(p.itembuttons!=false)
				    {
					    $.each(p.itembuttons,function(i,items){
						    var td=document.createElement("td");
						    var btnDiv=document.createElement("div");
						    btnDiv.className=items.className;
						    btnDiv.innerHTML=items.displayname;
						    if(items.onclick)
						    {
							    $(btnDiv).click(
								    function(){
									    items.onclick(items.name,row.id,p);
								    });
						    }
						    $(td).append(btnDiv);
						    $(tr).append(td);
					    });
				    }
    				
				    $(tr).hover(function(){$(this).addClass("trhover");},function(){$(this).removeClass("trhover");});
    				
				    $(tr).click(function(){
					    $("tr",table).removeClass("trSelected");
					    $(this).addClass("trSelected");
				    });
    				
				    $(tbody).append(tr);
			    });
		    }
		    else
		    {
			    var cols=1;
			    if(json.cols.length>0)
				    cols=json.cols.length;
				if(p.itembuttons)
					cols += p.itembuttons.length;
			    var tr=document.createElement("tr");
			    var td=document.createElement("td");
				$(td).attr("colspan",cols);
				//td.colspan=cols;
			    td.innerHTML=p.nodataMessage;
			    $(tr).append(td);
			    $(tbody).append(tr);
		    }
		    $(table).append(tbody);
		    $(showbox).append(table);
			//alert($(showbox).html());
		    $.AddPageInfo(showbox,p);
		}
		else
		{
		    location.href=p.loginpage;//未登陆状态,跳到指定登陆页面
		}
	};
	
	$.AddPageInfo=function(showbox,p)
	{
		var btnDiv=document.createElement("div");
		btnDiv.className="plistDiv"
		
		//生成分页信息
		
		var opt=""
		for(var nx=1;nx<=p.pages;nx++)
		{
			if (p.page==nx) sel = 'selected="selected"'; else sel = '';
				 opt += "<option value='" + nx + "' " + sel + " >" + nx + "&nbsp;&nbsp;</option>";	
		}
		btnDiv.innerHTML='<div class="pGroup"> <div class="pFirst pButton"><span></span></div><div class="pPrev pButton"><span></span></div> </div> <div class="btnseparator"></div> <div class="pGroup"><span class="pcontrol">Page '+p.page+' of <span> '+p.pages+' </span></span></div> <div class="btnseparator"></div> <div class="pGroup"> <div class="pNext pButton"><span></span></div><div class="pLast pButton"><span></span></div> </div> <div class="btnseparator"></div><div class="pGroup"><select name="rp">'+opt+'</select></div> <div class="btnseparator"></div> <div class="pGroup"> <div class="pReload pButton"><span></span></div> </div> <div class="btnseparator"></div> <div class="pGroup"><span class="pPageStat"></span></div>';
		
		$('.pReload',btnDiv).click(function(){$.BindGird(p,showbox);});
		$('.pFirst',btnDiv).click(function(){$.ChangePage('first','0',p,showbox);});
		$('.pPrev',btnDiv).click(function(){$.ChangePage('prev','0',p,showbox);});
		$('.pNext',btnDiv).click(function(){$.ChangePage('next','0',p,showbox);});
		$('.pLast',btnDiv).click(function(){$.ChangePage('last','0',p,showbox);});

		$("select",btnDiv).change(function(){
			$.ChangePage("select",this.value, p,showbox);
		});
		
		//显示状态信息
		
		var r1 = (p.page-1) * p.rp + 1; 
		if(p.total==0) r1=0;
		var r2 = r1 + p.rp - 1; 
			
		if (p.total<r2) r2 = p.total;
			
		var stat = p.pagestat;
			
		stat = stat.replace(/{from}/,r1);
		stat = stat.replace(/{to}/,r2);
		stat = stat.replace(/{total}/,p.total);
			
		$('.pPageStat',btnDiv).html(stat);
		
		$(showbox).append(btnDiv);
		var clearDiv=document.createElement("div");
		
		clearDiv.className="pClear";
		$(showbox).append(clearDiv);
		$(".JqueryGrid td").show("slow");
	};
	
	$.ChangePage=function(ctype,value,p,showbox)
	{
		switch(ctype)
		{
			case "first":p.page=1;break;
			case "prev": if(p.page>1) p.page=parseInt(p.page)-1;break;
			case "next": if(p.page<p.pages) p.page=parseInt(p.page)+1;break;
			case "last": p.page=p.pages;break;
			case "select": p.page=value;break
		}
		$.BindGird(p,showbox);
	};
	
})(jQuery);
