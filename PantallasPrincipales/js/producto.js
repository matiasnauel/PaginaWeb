window.onload = function() {
	 $.ajax({
        type: "GET",
        url: "https://localhost:44398/api/Publicacion/ProductoYcomentariosDePublicacion?publicacionID="+localStorage.getItem("publicacionID")+"&offset="+localStorage.getItem("offsetcomentario"),




        dataType: "json",	
		
		  success: function(data) {
			//$.each(data, function(i, item) {  
			  var producto = document.getElementById("producto");
			  producto.src='images/'+ data.imagen;
			  var precio = document.getElementById("precio");
			  precio.innerHTML= "$"+data.precio;
			  var nombre = document.getElementById("nombre");
			  nombre.innerHTML= data.nombre;
			  //var stock = document.getElementById("stock");
			  //stock.innerHTML=item.stock;
			  
			  
			  
			 //}); 
              	for (x = 0; x < data.comentarios.length; x++) 
				{
					
					
                 var div = document.createElement('div');
				 div.className="media";	
					
                 var div2 = document.createElement('div');
				 div2.className="media-left";
				 
				 var hr= document.createElement('hr');
				 
				 
				 var imagen = document.createElement('IMG');
                 imagen.src = 'images/fotoperfil.jpg';
				 imagen.className="img-rounded media-object";
				 imagen.setAttribute("width","60");
				 
				 div2.append(imagen);
				 
				  var div3 = document.createElement('div');
				  div3.className="media-right";
				 
				  var h4 = document.createElement('h4');
				  h4.className="media-heading";
				  h4.textContent="usuario";
				  
				  var p= document.createElement('p');
				  p.textContent= data.comentarios[x];
				  
				  div3.append(h4);
				  div3.append(p);
				  
                 div.append(div2);
				 div.append(hr);
				 div.append(div3);
				 div.append(hr);
				 $('#secciones').append(div);
  
                }	 
			  
		  },
		  error: function(error) {
            console.log(error.message);
            alert('error');
        }
		
		
		
		
	
	 });

	
}




function comentar()
{
	
	 var objeto = {
                    publicacionID: parseInt(localStorage.getItem("publicacionID")),
                    comentario: document.getElementById("comentario").value
                }
				
				
				
                    $.ajax({
                        url: 'https://localhost:44398/api/Comentario/InsertarComentarioPublicacion',
                        data: JSON.stringify(objeto),
                        type: "POST",
                        dataType: 'JSON',
                        contentType: "application/json",


                        success: function() {
                            location.reload();
                        }

                    });
	
	
	
}



function VerMas(){
	var offset = parseInt(localStorage.getItem("offsetcomentario"));
	offset=offset+3;
	localStorage.setItem("offsetcomentario",`${offset}`);
	 var objeto = {
                    PublicacionID: parseInt(localStorage.getItem("publicacionID")),
                    Offset: parseInt(localStorage.getItem("offsetcomentario"))
                }
	
                    $.ajax({
                        url: 'https://localhost:44398/api/Publicacion/PaginacionComentarios',
                        data: JSON.stringify(objeto),
                        type: "POST",
                        dataType: 'JSON',
                        contentType: "application/json",


                        success: function(data) {
                        	for (x = 0; x < data.length; x++) 
							{
							 var div = document.createElement('div');
				 div.className="media";	
					
                 var div2 = document.createElement('div');
				 div2.className="media-left";
				 
				 var hr= document.createElement('hr');
				 
				 
				 var imagen = document.createElement('IMG');
                 imagen.src = 'images/fotoperfil.jpg';
				 imagen.className="img-rounded media-object";
				 imagen.setAttribute("width","60");
				 
				 div2.append(imagen);
				 
				  var div3 = document.createElement('div');
				  div3.className="media-right";
				 
				  var h4 = document.createElement('h4');
				  h4.className="media-heading";
				  h4.textContent="usuario";
				  
				  var p= document.createElement('p');
				  p.textContent= data[x];
				  
				  div3.append(h4);
				  div3.append(p);
				  
                 div.append(div2);
				 div.append(hr);
				 div.append(div3);
				 div.append(hr);
				 $('#secciones').append(div);
							
							}		
                  
                        },
						 error: function(error) {
            console.log(error.message);
            alert('error');
        }
		

                    });
	
	
	
}






