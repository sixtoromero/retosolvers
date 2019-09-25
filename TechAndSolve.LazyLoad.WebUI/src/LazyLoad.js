import React, { Component } from 'react';


class LazyLoad extends Component {

    getFile(){
        var documento=document.getElementById("txtNroDocumento").value; 
        var path=document.getElementById("filepath").value;
        
        var sfilename = path.split('\\');
        
        if (documento != "" || path != ""){
            var uri = "http://localhost:50225/api/LazyLoading/" + sfilename[sfilename.length - 1] + "/" + documento;
            
            fetch(uri, 
                {
                    method: 'GET' 
                }).then(
                    (response) => response.json()
                ).then((responseJson) => {
                    console.log(responseJson);
              })
              .catch((error) => {
                console.error(error);
              });
        }
        else{
            alert('Es requerido un documento y una archivo seleccionado');
        }

    }

    render(){
        return (
            <div className="container">
                <div className="jumbotron text-center">
                    <h1>RETO SOLVERS</h1>
                    <p>Desarrollador .Net</p>
                </div>
                <div className="row">
                    <div className="col-lg-12 text-center">
                        <h3>Lazy Loading</h3>
                        <p>Maximizando los viajes</p>
                    </div>
                    <div className="col-lg-12">
                        <div className="form-group">
                            <label className="col-sm-2 control-label">
                                No. Documento:
                            </label>
                            <div className="col-sm-12">
                                <input id="txtNroDocumento" type="text" placeholder="Digite su documento" className="form-control" />
                            </div>
                        </div>
                    </div>
                    <div className="col-lg-12">
                        <label className="col-sm-3 control-label">
                            Seleccionar Archivo:
                        </label>
                        <div className="col-sm-12">
                            <div className="file-field">
                                <div className="btn btn-primary btn-sm float-left">
                                    <div className="btn btn-primary btn-sm float-left">
                                        <input type="file" id="filepath"></input>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-lg-12">
                        <br />
                        <div className="form-group">
                            <div className="col-sm-12">
                                <button type="button" className="btn btn-primary btn-lg btn-block" onClick={this.getFile}>Procesar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default LazyLoad;
