import { Usuario } from './models/usuario';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DataService } from './usuario.data';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  usuario!: Usuario;
  usuarioForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private service: DataService
  ) { }

  ngOnInit(): void {

    this.service.buscarUsuarios()
      .subscribe(
        (user) => { this.usuario = user; console.log(this.usuario) },
        (error) => { console.log(error) }
      );

    this.usuarioForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(150)]],
      sobrenome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(150)]],
      email: ['', [Validators.required, Validators.email]],
      datanascimento: [new Date(), Validators.required],
      escolaridade: ['', Validators.required,],
      ativo: [true, Validators.required,]
    });

    this.usuarioForm.patchValue({
      nome: this.usuario?.nome,
      sobrenome: this.usuario?.sobrenome,
      email: this.usuario?.email,
      ativo: this.usuario?.ativo
    });

  }
  onSubmit() {
    this.usuario = this.usuarioForm.value;
    this.service.Adicionar(this.usuario).subscribe(
      (user: Usuario) => { console.log(user) },
      (error) => { console.log(error) }
    )

  }
  onEdit() {
    this.usuario = this.usuarioForm.value;
    this.service.Atualizar(this.usuario).subscribe(
      (user: Usuario) => { console.log(user) },
      (error) => { console.log(error) }
    )

  }

  onDelete() {
    this.usuario = this.usuarioForm.value;
    this.service.Remover(this.usuario.id).subscribe(
      (user: any) => { console.log(user) },
      (error) => { console.log(error) }
    )

  }
}
