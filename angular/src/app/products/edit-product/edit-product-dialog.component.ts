import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  ProductsServiceProxy,
  ProductDto,
  ProductTranslationDto
} from '@shared/service-proxies/service-proxies';
import { filter as _filter } from 'lodash-es';

@Component({
  templateUrl: 'edit-product-dialog.component.html'
})
export class EditProductDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  public languages: abp.localization.ILanguageInfo[];
  langTranslation: ProductTranslationDto[] = [];
  product: ProductDto = new ProductDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _productService: ProductsServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.languages = _filter(
      this.localization.languages,
      (l) => !l.isDisabled
    );
    this._productService.getProduct(this.id).subscribe((result: ProductDto) => {
      this.product = result;
      this.languages.forEach(lang => {
        this.langTranslation[lang.name] = ProductTranslationDto.fromJS({
          name: this.product.translations?.find(pt => pt.language === lang.name)?.name,
          language: lang.name
        });
      });
    });
    
  }

  save(): void {
    this.saving = true;

    this.product.translations = Object.keys(this.langTranslation).map(k => {
      if (this.langTranslation[k].name) {
        return this.langTranslation[k];
      } 
    }).filter(el => el);

    this._productService.updateProduct(this.product).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
