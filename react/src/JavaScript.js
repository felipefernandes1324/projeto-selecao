import React, { Component } from "react"
import { Link } from 'react-router-dom'
import axios from "axios"

export class FetchProduto extends Component {
    static displayName = "Fornecedor";
    constructor() {
        super();
        this.state = { fornecedor: [], loading: true }
    }
    componentDidMount() {
        this.populaFornecedorData();
    }
    static handleEdit(fornecedorCNPJ) {
        window.location.href = "/Fornecedor/Edit/" + fornecedorCNPJ;
    }

    static handleDelete(fornecedorCNPJ) {
        if (!window.confirm("Você deseja deletar o produto : " + fornecedorCNPJ)) {
            return;
        }
        else {
            fetch('api/Fornecedor/' + fornecedorCNPJ, { method: 'delete' })
                .then(json => {
                    window.location.href = "fetch-fornecedor";
                    alert('Deletado com Sucesso!');
                })
        }
    }
    static renderFornecedorTabela(fornecedor) {

        
        return  (
            <table className='table table-striped' aria-labelledby="tabelLabel" >
                <thead>
                    <tr>
                        <th>CNPJ</th>
                        <th>UF</th>
                        <th>Razão Social</th>
                        <th>Email</th>
                        <th>Nome do contato</th>

                    </tr>
                </thead>
                <tbody>
                    {forn.map(forn =>
                        <tr key={for.fornecedorCNPJ}>
                        <td>{prod.fornecedorUf}</td>
                        <td>{prod.fornecedorRazao}</td>
                        <td>{prod.fornecedorEmail}</td>
                        <td>{prod.fornecedorContato}</td>

                            <td>
                                <button className="btn btn-success" onClick={(id) => this.handleEdit(prod.id)}>Edit</button> &nbsp;
                                <button className="btn btn-danger" onClick={(id) => this.handleDelete(prod.id)}>Delete</button>
                            </td>

                        </tr>

                    )}
                </tbody>
            </table>
        );

    }
    async populaFornecedorData() {
        const response = await fetch('api/Fornecedor');
        const data = await response.json();
        this.setState({ fornecedor: data, loading: false });
    }
}
