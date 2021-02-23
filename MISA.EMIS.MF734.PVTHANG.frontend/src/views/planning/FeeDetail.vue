<template>
    <div id="fee-detail">
        <div class="modal"></div>
        <div class="dialog">
            <div class="dialog__header">
                <div class="title">{{mode==="ADD"? "Thêm khoản thu": mode==="EDIT"? "Sửa khoản thu":"..."}}</div>
                <div class="icon icon-x" @click="close"></div>
            </div>
            <div class="dialog__content">
                <div class="content__left">
                    <div class="row">
                        <div class="text">Tên khoản thu <span class="m-red">*</span></div>
                        <div class="input">
                            <input type="text" size="100"
                                @blur="validateData('FeeName')" 
                                ref="FeeName"
                                :class="{'m-input': true, 'error-required': !validate.FeeName.Status}"
                                :title="validate.FeeName.Status? null:validate.FeeName.message"
                                v-model="fee.FeeName"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text">Thuộc nhóm khoản thu</div>
                        <div class="input">
                            <select name="feeGroup" v-model="fee.FeeGroupID" class="m-select">
                                <option v-for="(feeGroup,index) in listFeeGroup" :key="index" 
                                    :value="feeGroup.FeeGroupID"
                                    >{{feeGroup.FeeGroupName}}</option>
                            </select>
                        </div>
                    </div>
                    <div class="row m-flex">
                        <div class="m-flex-3">
                            <div class="text">Mức thu <span class="m-red">*</span></div>
                            <div class="input">
                                <input type="number" 
                                    v-model="fee.Price"
                                    @blur="validateData('Price')" 
                                    :class="{'m-input': true, 'error-required': !validate.Price.Status, 'm-text-right': true}"
                                    :title="validate.Price.Status? null:validate.Price.message" /> 
                                <label>đ/</label>
                            </div>
                        </div>
                        <div class="m-flex-1">
                            <div class="text">Đơn vị tính <span class="m-red">*</span></div>
                            <div class="input">
                                <select name="unit" v-model="fee.Unit"
                                    @blur="validateData('Unit')" 
                                    :class="{'m-select': true, 'error-required': !validate.Unit.Status}"
                                    :title="validate.Unit.Status? null:validate.Unit.message">
                                    <option value="1">Ngày</option>
                                    <option value="2">Tuần</option>
                                    <option value="3">Tháng</option>
                                    <option value="4">Học kỳ</option>
                                    <option value="5">Năm</option>
                                </select>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text">Phạm vi thu <span class="m-red">*</span></div>
                        <div class="input">
                            <select name="applyObject"
                                v-model="fee.ApplyObject"
                                @blur="validateData('ApplyObject')" 
                                :class="{'m-select': true, 'error-required': !validate.ApplyObject.Status}"
                                :title="validate.ApplyObject.Status? null:validate.ApplyObject.message">
                                <option value="Cá nhân">Cá nhân</option>
                                <option value="Lớp">Lớp</option>
                                <option value="Khối">Khối</option>
                                <option value="Toàn trường">Toàn trường</option>
                            </select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text">Tính chất</div>
                        <div class="input">
                            <select name="property" class="m-select" v-model="fee.Property">
                                <option value="0">Thu theo thỏa thuận</option>
                                <option value="1">Chi phí phát sinh</option>
                            </select>
                        </div>
                    </div>
                    <div class="row">
                        <div class="text">Kỳ thu <span class="m-red">*</span></div>
                        <div class="input">
                            <div class="m-flex m-flex-1">
                                <input type="radio" name="period" v-model="fee.Period" value="1" id="1-period"/>
                                <label for="1-period"><span></span>Tháng</label>
                            </div>
                            <div class="m-flex m-flex-1">
                                <input type="radio" name="period" v-model="fee.Period" value="2" id="2-period"/>
                                <label for="2-period"><span></span>Quý</label>
                            </div>
                            <div class="m-flex m-flex-1">
                                <input type="radio" name="period" v-model="fee.Period" value="3" id="3-period"/>
                                <label for="3-period"><span></span>Học kỳ</label>
                            </div>
                            <div class="m-flex m-flex-1">
                                <input type="radio" name="period" v-model="fee.Period" value="4" id="4-period"/>
                                <label for="4-period"><span></span>Năm học</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content__right">
                    <div class="row m-flex">
                        <div class="m-flex-1">
                            <input type="checkbox" id="IsApplyRemisson" v-model="fee.IsApplyRemisson"/>
                            <label for="IsApplyRemisson"><span></span>Áp dụng miễn giảm</label>
                        </div>
                        <div class="m-flex-1">
                            <input type="checkbox" id="AllowCreateReceipt" v-model="fee.AllowCreateReceipt"/>
                            <label for="AllowCreateReceipt"><span></span>Cho phép xuất chứng từ</label>
                        </div>
                    </div>
                    <div class="row m-flex">
                        <div class="m-flex-1">
                            <input type="checkbox" id="IsRequire" v-model="fee.IsRequire"/>
                            <label for="IsRequire"><span></span>Khoản thu bắt buộc</label>
                        </div>
                        <div class="m-flex-1">
                            <input type="checkbox" id="IsInternal" v-model="fee.IsInternal" :disabled="mode === 'ADD'"/>
                            <label for="IsInternal"><span></span>Cho phép hoàn trả</label>
                        </div>
                    </div>
                    <div class="row m-flex">
                        <div class="m-flex-1">
                            <input type="checkbox" id="AllowCreateInvoice" v-model="fee.AllowCreateInvoice"/>
                            <label for="AllowCreateInvoice"><span></span>Cho phép xuất hóa đơn</label>
                        </div>
                        <div class="m-flex-1">
                            <input type="checkbox" id="IsSystem" v-model="fee.IsSystem"/>
                            <label for="IsSystem"><span></span>Thu nội bộ</label>
                        </div>
                    </div>
                    <div class="row m-flex">
                        <div class="m-flex-1">
                            <input type="checkbox" id="register-type" disabled/>
                            <label for="register-type"><span class="m-switch-input"></span>Phân loại đăng ký</label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="dialog__footer">
                <div class="footer__item float--left" v-if="mode === 'EDIT'">
                    <input type="checkbox" id="IsActive" v-model="fee.IsActive"/>
                    <label for="IsActive"><span class="convert"></span>Ngừng theo dõi</label>
                </div>
                <div class="footer__item float--right">
                    <button class="m-button" @click="saveOnClick(true)">Lưu</button>
                </div>
                <div class="footer__item float--right" v-if="mode === 'ADD'">
                    <button class="m-button" @click="saveOnClick(false)">Lưu và thêm mới</button>
                </div>
                <div class="footer__item float--right">
                    <button class="m-second-button" @click="close()">Đóng</button>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import axios from 'axios'

export default {
    data() {
        return {
            fee: {
                FeeName: "",
                FeeGroupID: null,
                Price: null,
                Unit: 2,
                ApplyObject: "Toàn trường",
                Property: null,
                Period: 1,
                IsApplyRemisson: false,
                IsRequire: false,
                AllowCreateInvoice: true,
                AllowCreateReceipt: true,
                IsActive: true,
                IsInternal: false,
                IsSystem: false
            },
            validate: {
                FeeName: {
                    Status: true,
                    Require: true,
                    message: ""
                },
                Price: {
                    Status: true,
                    Require: true,
                    message: ""
                },
                Unit: {
                    Status: true,
                    Require: true,
                    message: ""
                },
                ApplyObject: {
                    Status: true,
                    Require: true,
                    message: ""
                },
                Period: {
                    Status: true,
                    Require: true,
                    message: ""
                },
                IsApplyRemisson: {
                    Status: true,
                    Require: true,
                    message: ""
                },
                IsRequire: {
                    Status: true,
                    Require: true,
                    message: ""
                },
                AllowCreateInvoice: {
                    Status: true,
                    Require: true,
                    message: ""
                },
                AllowCreateReceipt: {
                    Status: true,
                    Require: true,
                    message: ""
                },
                IsActive: {
                    Status: true,
                    Require: true,
                    message: ""
                },
                IsInternal: {
                    Status: true,
                    Require: true,
                    message: ""
                },
                IsSystem: {
                    Status: true,
                    Require: true,
                    message: ""
                }
            }
        }
    },
    props: {
        mode: String,
        listFeeGroup: Array,
        feeId: Number
    },
    methods: {
        close() {
            this.$emit('close');
        },
        reload() {
            this.$emit('reloadData');
        },
        validateData(key) {
            if (this.validate[key].Require == true && (this.fee[key] === null || this.fee[key] === "")) {
                this.validate[key].Status = false;
                this.validate[key].message = "Bạn phải nhập thông tin này."
            } else {
                this.validate[key].Status = true;
            }
        },
        saveOnClick(close) {
            var flag = true;
            for (var key in this.validate) {
                this.validateData(key);
                if (this.validate[key].Status === false) {
                    flag = false;
                }
            }
            if (flag && this.mode === 'ADD') {
                this.fee.FeeID = null;
                axios.post('http://localhost:60931/api/v1/Fees', this.fee)
                .then(res => {
                    console.log(res.data);
                    this.reload();
                    if (close) {
                        this.close();
                    } else {
                        this.fee = {
                            FeeName: "",
                            FeeGroupID: null,
                            Price: null,
                            Unit: 2,
                            ApplyObject: "Toàn trường",
                            Property: null,
                            Period: 1,
                            IsApplyRemisson: false,
                            IsRequire: false,
                            AllowCreateInvoice: true,
                            AllowCreateReceipt: true,
                            IsActive: true,
                            IsInternal: false,
                            IsSystem: false
                        }
                        this.$refs.FeeName.focus();
                    }
                })
                .catch((err) => {
                    alert(err);
                })
            } else if (flag && this.mode === 'EDIT') {
                axios.put('http://localhost:60931/api/v1/Fees', this.fee)
                .then(res => {
                    console.log(res.data);
                    this.reload();
                    this.close();
                })
                .catch((err) => {
                    alert(err);
                })
            }
        }
    },
    mounted() {
        this.$refs.FeeName.focus();
        if (this.feeId !== null) {
            axios.get('http://localhost:60931/api/v1/Fees/' + this.feeId)
                .then(res => {
                    this.fee = res.data;
                })
                .catch(res => {
                    alert(res);
                })
        }
    }
}
</script>
<style scoped>
.modal {
    position: fixed;
    width: 100vw;
    height: 100vh;
    top: 0;
    left: 0;
    background-color: #cccccc;
    opacity: 0.6;
    z-index: 3;
}

.dialog {
    position: fixed;
    z-index: 3;
    width: calc(1000px - 24px - 24px);
    height: 600px;
    top: calc((100vh - 600px) / 2);
    left: calc((100vw - 1000px) / 2);
    background-color: #fff;
    border-radius: 4px;
    padding-left: 24px;
    padding-right: 24px;
    overflow: hidden;
}

    .dialog .dialog__header {
        display: flex;
        align-items: center;
        width: 100%;
        height: 70px;
        overflow: hidden;
    }

        .dialog .dialog__header .title {
            font-family: 'OpenSans-Bold';
            font-size: 20px;
        }

        .dialog .dialog__header .icon {
            position: absolute;
            top: 12px;
            right: 12px;
            width: 16px;
            height: 16px;
            border-radius: 50%;
            cursor: pointer;
        }

    .dialog .dialog__content {
        display: flex;
        width: 100%;
        height: calc(100% - 70px - 70px);
    }

        .dialog .dialog__content .content__left{
            flex: 1;
            padding: 12px 24px 12px 0;
            height: calc(100% - 24px);
            border-right: 1px solid #cccccc;
        }

            .dialog .dialog__content .content__left .row {
                width: 100%;
                height: 66px;
            }

                .dialog .dialog__content .content__left .row .text{
                    line-height: 32px;
                }

                .dialog .dialog__content .content__left .row .input{
                    display: flex;
                }

                    .dialog .dialog__content .content__left .row .input label{
                        display: flex;
                        align-items: center;
                        padding: 0 4px 0 4px;
                    }

        .dialog .dialog__content .content__right{
            flex: 1;
            height: calc(100% - 24px);
            padding: 12px 0 12px 24px;
        }

            .dialog .dialog__content .content__right .row{
                width: 100%;
                height: 40px;
                overflow: hidden;
            }

            .dialog .dialog__content .content__right .row > div{
                display: flex;
                align-items: center;
            }

    .dialog .dialog__footer {
        width: 100%;
        height: 70px;
    }

        .dialog .dialog__footer .footer__item {
            height: 100%;
            display: flex;
            align-items: center;
        }

        .dialog .dialog__footer .footer__item.float--right {
            margin-left: 8px;
        }
.error-required {
    border: 1px solid red;
}
</style>