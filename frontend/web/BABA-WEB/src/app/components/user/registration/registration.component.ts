import { FormGroup, FormBuilder, Validators, AbstractControlOptions } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ValidatorField } from '@app/helpers/ValidatorField.ts';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  form!: FormGroup;

  constructor(public fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }
  ngAfterContentInit(){

  }
  private validation(): void {
    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('senha', 'confirmeSenha')
    };
    this.form = this.fb.group({
      primeiroNome:['', Validators.required ],
      segundoNome:['', Validators.required ],
      email:['', [Validators.required, Validators.email ]],
      userName:['', Validators.required ],
      senha:['', [Validators.required, Validators.minLength(6)] ],
      confirmeSenha:['', Validators.required ],
    }, formOptions)

  }
  get f():any{
    return this.form.controls;
  }
}
